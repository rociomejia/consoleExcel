using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CSSD.IS.ProfLearn.Util
{
    public class DbConnectionHandler
    {
        public void OpenDbConnection(DbConnection dbConnection)
        {
            if (dbConnection == null)
            {
                throw new Exception("Database Connection is null");
            }
            else
            {
                dbConnection.Open();
            }
        }

        public void CloseDbConnection(DbConnection dbConnection)
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }

        }

        public DbConnection GetOleConnection(string connectionString)
        {
            return new OleDbConnection(connectionString);
        }

        public DbConnection GetOdbcConnection(string connectionString)
        {
            return new OdbcConnection(connectionString);
        }

        public DbConnection GetSqlConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
