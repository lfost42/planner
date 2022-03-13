using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Dapper;
=======
>>>>>>> 4be4c1640f496c59e24882d0fd6015ab93722ebf
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SoftwarePlannerLibrary.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public List<T> LoadData<T, U>(string sqlStatement,
                                      U parameters,
                                      string connectionStringName,
                                      bool isStoredProcedure = false)
        {

            string connectionString = _config.GetConnectionString(connectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

<<<<<<< HEAD
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
=======
            using (IDbConnection connection = new SqlConnection(connectionString))
>>>>>>> 4be4c1640f496c59e24882d0fd6015ab93722ebf
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
                return rows;
            }

        }

        public void SaveData<T>(string sqlStatement,
                                T parameters,
                                string ConnectionStringName,
                                bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

<<<<<<< HEAD
            using (IDbConnection connection = new NpgsqlConnection(connectionString))
=======
            using (IDbConnection connection = new SqlConnection(connectionString))
>>>>>>> 4be4c1640f496c59e24882d0fd6015ab93722ebf
            {
                connection.Execute(sqlStatement, parameters, commandType: commandType);
            }

        }
    }
}
