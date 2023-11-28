using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using GuestDataManager.Library.DataAccess;
using System.Reflection;
using GuestRegistrationDesktopUI.Library.Models;

namespace GuestDataManager.Library.Internal.DataAccess
{
    class SqlDataAccess
    {
        VisitorInformation visitor = new VisitorInformation();
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
                var test = connection.Query<T>(storedProcedure, parameter,
                    commandType: CommandType.StoredProcedure);

                List<T> rows = connection.Query<T>(storedProcedure, parameter,
                    commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }
        public VisitorInformation LoadData(string storedProcedure, Dictionary<string, object> parameter, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var kvp in parameter)
                {
                    command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PropertyInfo[] properties = visitor.GetType().GetProperties();

                        foreach (PropertyInfo property in properties)
                        {
                            int ordinal = reader.GetOrdinal(property.Name);
                            if (!reader.IsDBNull(ordinal))
                            {
                                object value = reader.GetValue(ordinal);
                                if (value is DateTime)
                                {
                                    value = ((DateTime)value).ToString("yyyy-MM-dd");
                                }
                                if (value is false || value is bool)
                                {
                                    value = Convert.ToBoolean(value) ? 0 : 1;
                                }

                                property.SetValue(visitor, value);
                            }
                        }
                    }
                }
                connection.Close();
                return visitor;
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
        public void SaveData(string storedProcedure, Dictionary<string, object> parameter, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var kvp in parameter)
                {
                    command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                }
                //output parameter
                //SqlParameter resultParameter = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                //resultParameter.Direction = System.Data.ParameterDirection.Output;
                //command.Parameters.Add(resultParameter);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
