
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL{
    /**
     * 
     */
    public class Connection {

        /**
         * 
         */
        public Connection() {
        }

        /**
         * 
         */
        private String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        /**
         * 
         */
        public SqlConnection connection;

        public void Open() {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        /**
         * 
         */
        public void Close() {
            connection.Close();
        }

    }
}