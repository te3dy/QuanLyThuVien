
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /**
     * 
     */
    public class Connection
    {

        /**
         * 
         */
        public Connection()
        {
        }

        /**
         * 
         */
        //private String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        //private String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection2"].ConnectionString;
        private String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection3"].ConnectionString;
        /**
         * 
         */
        public SqlConnection sqlConnection;

        public void Open()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        /**
         * 
         */
        public void Close()
        {
            sqlConnection.Close();
        }

    }
}