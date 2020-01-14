using System;
using System.Data;
using System.Configuration;
using System.Security;


namespace CSSD.IS.ProfLearn.Util
{
    public class BaseProcess
    {
        string _connString;
        public string ConnString
        {
            get { return _connString; }
            set {_connString = value;}
        }
        public BaseProcess()
        {
            //string databaseServer = ConfigurationManager.AppSettings.Get(Constants.DatabaseServer);
            //** IDHS Dev DB Server:
            String databaseServerName="";
            string values_environment = ConfigurationManager.AppSettings.Get("Environment");
            if (values_environment == "DEV")
            {   
                
                databaseServerName = ConfigurationManager.AppSettings.Get("DevDatabaseServer");

            }
            if (values_environment == "TEST")
            {
                
                databaseServerName = ConfigurationManager.AppSettings.Get("TestDatabaseServer");
            }
            if (values_environment == "PROD")
            {
                databaseServerName = ConfigurationManager.AppSettings.Get("ProdDatabaseServer");
            }



            if (databaseServerName.Equals(Constants.SQL_SERVER_620_21_NAME))
            {
                _connString = ConfigurationManager.AppSettings.Get(Constants.DevConnectionString);                
            }
            //** IDHS Test DB Server:
            else if (databaseServerName.Equals(Constants.SQL_SERVER_634_01_NAME))
            {
                _connString = ConfigurationManager.AppSettings.Get(Constants.TestConnectionString);                
            }
            //** IHDS Prod DB Server:
            else if (databaseServerName.Equals(Constants.SQL_SERVER_611_03_NAME))
            {
                _connString = ConfigurationManager.AppSettings.Get(Constants.ProdConnectionString);                
            }
        }
    }
}
