using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Dal
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
            : this(ConfigurationManager.ConnectionStrings["PressfordNews"].ToString())
        { }

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates and opens a new connection from provided connection string
        /// </summary>
        public SqlConnection NewConnection
        {
            get
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
        }
    }
}
