using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public sealed class VisitRepository(StoragePaths paths, IConfiguration configuration)
{
    string ConnectionString()
    {
        var configured = configuration.GetConnectionString("GuestData");
        if (!string.IsNullOrWhiteSpace(configured)) return configured;
        if (!OperatingSystem.IsWindows()) throw new InvalidOperationException("Configure ConnectionStrings:GuestData.");
        var secret = File.ReadAllBytes(Path.Combine(paths.Root,"Data","database.secret"));
        return Encoding.UTF8.GetString(ProtectedData.Unprotect(secret, null, DataProtectionScope.CurrentUser));
    }
    async Task<SqlConnection> Open()
    {
        var connection=new SqlConnection(ConnectionString());
        try { await connection.OpenAsync();return connection; } catch { await connection.DisposeAsync();throw; }
    }
    public async Task Initialize()
    {
        await using var connection=await Open();
        await using var command=connection.CreateCommand();
        command.CommandText="IF OBJECT_ID('dbo.ReceptionVisits','U') IS NULL CREATE TABLE dbo.ReceptionVisits(Id uniqueidentifier NOT NULL PRIMARY KEY, Payload nvarchar(max) NOT NULL CHECK(ISJSON(Payload)=1));";
        await command.ExecuteNonQueryAsync();
        // Import previous local records without overwriting a newer SQL record.
        foreach(var file in Directory.GetFiles(paths.Records,"*.json")) {
            var record=JsonSerializer.Deserialize<Visit>(await File.ReadAllTextAsync(file));
            if(record is null)continue;
            command.CommandText="IF NOT EXISTS(SELECT 1 FROM dbo.ReceptionVisits WHERE Id=@id) INSERT dbo.ReceptionVisits(Id,Payload) VALUES(@id,@payload)";
            command.Parameters.Clear();command.Parameters.Add("@id",SqlDbType.UniqueIdentifier).Value=record.Id;
            command.Parameters.Add("@payload",SqlDbType.NVarChar,-1).Value=JsonSerializer.Serialize(record);
            await command.ExecuteNonQueryAsync();
        }
    }
    public async Task<List<Visit>> List()
    {
        await using var connection=await Open();await using var command=connection.CreateCommand();command.CommandText="SELECT Payload FROM dbo.ReceptionVisits";
        await using var reader=await command.ExecuteReaderAsync();var records=new List<Visit>();
        while(await reader.ReadAsync())records.Add(JsonSerializer.Deserialize<Visit>(reader.GetString(0))!);
        return records.OrderByDescending(v=>v.CheckIn).ToList();
    }
    public async Task<Visit?> Get(Guid id)
    {
        await using var connection=await Open();await using var command=connection.CreateCommand();command.CommandText="SELECT Payload FROM dbo.ReceptionVisits WHERE Id=@id";
        command.Parameters.Add("@id",SqlDbType.UniqueIdentifier).Value=id;
        var result=await command.ExecuteScalarAsync();return result is string json?JsonSerializer.Deserialize<Visit>(json):null;
    }
    public async Task Save(Visit visit,bool create=false)
    {
        await using var connection=await Open();await using var command=connection.CreateCommand();
        command.CommandText=create?"INSERT dbo.ReceptionVisits(Id,Payload) VALUES(@id,@payload)":"UPDATE dbo.ReceptionVisits SET Payload=@payload WHERE Id=@id";
        command.Parameters.Add("@id",SqlDbType.UniqueIdentifier).Value=visit.Id;
        command.Parameters.Add("@payload",SqlDbType.NVarChar,-1).Value=JsonSerializer.Serialize(visit);
        if(await command.ExecuteNonQueryAsync()!=1)throw new InvalidOperationException("Registration was not saved.");
    }
}
