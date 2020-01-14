using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using CSSD.IS.ProfLearn.DataEntityModel;
//using CSSD.IS.ProfLearn.DataAccess;
//using CSSD.IS.ProfLearn.BusinessFacade;
//using CSSD.IS.ProfLearn.BusinessLogic;
using CSSD.IS.ProfLearn.Util;

using WinSCP;
using ProfLearn.Common;

namespace CSSD.IS.ProfLearn.Console
{
    public class Program
    {
        static void Main(string[] args)
        {

            string databaseServerName = "";
            string skipFilename = "";
            string fileName = "";

            string values_environment = ConfigurationManager.AppSettings.Get("Environment");
            if (values_environment == "DEV")
            {
                fileName = ConfigurationManager.AppSettings.Get("DevFileName");
                skipFilename = ConfigurationManager.AppSettings.Get("DevSkipFilename");
                databaseServerName = ConfigurationManager.AppSettings.Get("DevDatabaseServer");
            }

            if (values_environment == "TEST")
            {
                fileName = ConfigurationManager.AppSettings.Get("TestFileName");
                skipFilename = ConfigurationManager.AppSettings.Get("TestSkipFilename");
                databaseServerName = ConfigurationManager.AppSettings.Get("TestDatabaseServer");

            }

            if (values_environment == "PROD")
            {
                fileName = ConfigurationManager.AppSettings.Get("ProdFileName");
                skipFilename = ConfigurationManager.AppSettings.Get("ProdSkipFilename");
                databaseServerName = ConfigurationManager.AppSettings.Get("ProdDatabaseServer");

            }


            #region main block:
            try
            {

                //string[] usersSkip_array = System.IO.File.ReadAllLines(skipFilename);

                ExportToExcel excelFile = new ExportToExcel(fileName);

                excelFile.GenerateReport(usersSkip_array);
                //if file exist try to transfer. Commented to avoid accident trying to put on  sftp server until Nov 27
              //  FTPExcelFiles(databaseServerName);

                System.Console.WriteLine("Process completed " + fileName);
                AppLog.GetAppLog().Log("Process completed " + fileName);
                //System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                AppLog.GetAppLog().Log("The task is terminated - Program.cs- " + ex.Message);
            }
            #endregion main block           
        }


        private static void FTPExcelFiles(string databaseServerName)
        {
            try
            {
                string serverCorePath = "";
                string fileName = "";
                string values_environment = ConfigurationManager.AppSettings.Get("Environment");
                String SshPrivateKeyPath = ConfigurationManager.AppSettings.Get("SshPrivateKeyPath");
                String winSCP_Path = ConfigurationManager.AppSettings.Get("winscp_Path");

                if (values_environment == "DEV")
                {
                    fileName = ConfigurationManager.AppSettings.Get("DevFilename");
                }

                if (values_environment == "PROD")
                {
                    fileName = ConfigurationManager.AppSettings.Get("ProdFilename");
                }

                if (values_environment == "TEST")
                {
                    fileName = ConfigurationManager.AppSettings.Get("TestFilename");
                }

                //* IDHS Dev:
                if (databaseServerName.Equals(Constants.SQL_SERVER_620_21_NAME))
                {
                    serverCorePath = Constants.SFTPTestCorePath;
                }
                //* IDHS Test:
                else if (databaseServerName.Equals(Constants.SQL_SERVER_634_01_NAME))
                {
                    serverCorePath = Constants.SFTPTestCorePath;
                }
                //* IDHS Prod:
                else if (databaseServerName.Equals(Constants.SQL_SERVER_611_03_NAME))
                {
                    serverCorePath = Constants.SFTPProdCorePath;
                }
                else
                {
                    AppLog.GetAppLog().Log("Wrong database server name: " + databaseServerName);
                    AppLog.GetAppLog().HasError = true;
                    throw new Exception("Wrong database server name: " + databaseServerName);
                }


                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = Constants.SFTPHostName,
                    UserName = Constants.SFTPUserName,
                    Password = Constants.SFTPPassword,
                    SshHostKeyFingerprint = Constants.SFTPSshHostKeyFingerprint,
                    PortNumber = Constants.SFTPPortNumber,
                    PrivateKeyPassphrase = Constants.PrivateKeyPassphrase,
                    //SshPrivateKeyPath key file to connecto to sftp host server
                    SshPrivateKeyPath = SshPrivateKeyPath
                };

                AppLog.GetAppLog().Log("Done SFTP session options setting.");
                using (Session session = new Session())
                {
                    //* Connect
                    try
                    {
                        session.ExecutablePath = winSCP_Path;
                        session.Open(sessionOptions);
                    }
                    catch (Exception e)
                    {
                        AppLog.GetAppLog().Log("Could not open WinSCP ln 51 on program.cs " + e.Message);
                        throw new Exception(e.Message);
                    }

                    AppLog.GetAppLog().Log("Open SFTP Session...");

                    //* Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    transferOptions.FilePermissions = null;
                    transferOptions.PreserveTimestamp = false;

                    //** Upload core XML files:
                    TransferOperationResult coreTransferResult;
                    //coreTransferResult = session.PutFiles(sourceFilePath + @"CSSD_Core_*", serverCorePath, false, transferOptions);
                    coreTransferResult = session.PutFiles(fileName, serverCorePath, false, transferOptions);
                    //* Throw on any error
                    coreTransferResult.Check();
                    //* Log core results
                    bool coreFilesExisting = false;
                    foreach (TransferEventArgs transfer in coreTransferResult.Transfers)
                    {
                        coreFilesExisting = true;
                        AppLog.GetAppLog().Log("Upload file succeeded: " + transfer.FileName);
                    }
                    if (coreFilesExisting)
                    {
                        //coreTransferResult = session.PutFiles(sourceFilePath + Constants.SFTPFlagFile, serverCorePath, false, transferOptions);
                        coreTransferResult = session.PutFiles(fileName, serverCorePath, false, transferOptions);
                        AppLog.GetAppLog().Log("Uploaded file to vendor's SFTP host.");
                    }

                }
            }
            catch (Exception ex)
            {
                AppLog.GetAppLog().Log("Error: occurred in SFTP xml files.");
                AppLog.GetAppLog().Log(ex.ToString());
                AppLog.GetAppLog().HasError = true;
                throw ex;
            }

            AppLog.GetAppLog().Log("SFTP Process is done.");
        }


    }
}