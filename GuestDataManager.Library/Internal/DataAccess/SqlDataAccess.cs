using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace GuestDataManager.Library.Internal.DataAccess
{
    class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            //ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap
            //{
            //    ExeConfigFilename = "D:\\00 Project Repository\\GuestRegistrationForm\\GuestRegistrationForm\\GuestRegistration\\Web.config"
            //};
            //Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.PerUserRoaming);

            //return config.AppSettings.CurrentConfiguration.ConnectionStrings.ConnectionStrings[name].ConnectionString;

            return CONSTANTS.connString;

            //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameter, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameter,
                    commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameter, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameter,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
