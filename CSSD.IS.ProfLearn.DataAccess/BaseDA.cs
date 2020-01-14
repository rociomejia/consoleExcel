using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.Common;

namespace CSSD.IS.ProfLearn.DataAccess

{
    public abstract class BaseDA
    {
        //Database command timeout in seconds
        protected const int DB_COMMAND_TIMEOUT = 1500;

        DbConnection m_dbConnection;
        public DbConnection DatabaseConnection
        {
            set
            {
                m_dbConnection = value;
            }
            get
            {
                return m_dbConnection;
            }
        }

        public BaseDA(DbConnection dbConnection)
        {
            m_dbConnection = dbConnection;
        }

        public abstract object ExecuteScalar(string sql);
        public abstract void ExecuteNonQuery(string sql);
        protected abstract DbCommand GetDbCommand(string query);

        protected String GetColumnString(IDataReader reader, string colName)
        {
            int index = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(index))
            {
                return reader.GetString(index).Trim();
            }
            return null;
        }

        protected Int32? GetColumnInt32(IDataReader reader, string colName)
        {
            int index = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(index))
            {
                return reader.GetInt32(index);
            }
            return null;
        }

        protected Boolean GetColumnBoolean(IDataReader reader, string colName)
        {
            int index = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(index))
            {
                return reader.GetBoolean(index);
            }
            return false;
        }

        protected DateTime? GetColumnDatetime(IDataReader reader, string colName)
        {
            int index = reader.GetOrdinal(colName);
            if (!reader.IsDBNull(index))
            {
                return reader.GetDateTime(index);
            }
            return null;
        }
    }
}
