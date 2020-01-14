using System;
using System.Collections.Generic;
using System.Text;
namespace CSSD.IS.ProfLearn.Util

{
    public class Constants
    {
        public const string DevConnectionString = "DevConnectionString";
        public const string TestConnectionString = "TestConnectionString";
        public const string ProdConnectionString = "ProdConnectionString";
  
        //** IDHS Dev DB Server:
        public const string SQL_SERVER_620_21_NAME = "s096-a0620-21";
       
        //** IHDS Test DB Server:
        public const string SQL_SERVER_634_01_NAME = "s096-a0634-01";
       
        //** IHDS Prod DB Server:
        public const string SQL_SERVER_611_03_NAME = "s096-a0611-03";
        
        public const string DatabaseServer = "DatabaseServer";

        //** D2L SFTP Constants:
        public const string SFTPTestCorePath = @"/inbox/";
       
        public const string SFTPProdCorePath = @"/inbox/";

        //** Thrive SFTP Constants:
        public const string SFTPHostName = "thrivecn-integration.teachermatch.org";
        public const string SFTPUserName = "calg";
        public const string SFTPPassword = "";
        public const string SFTPSshHostKeyFingerprint = "ssh-rsa 2048 42:c2:a4:4b:ef:b9:d9:34:02:39:4c:79:29:59:ec:fb";
        public const string SFTPFlagFile = "RUNCCSD.txt";
        public const int SFTPPortNumber= 22;
        public const string SFTPDebugLogLevel = "";
        public const string PrivateKeyPassphrase = "catholic";                
        //public const string SshPrivateKeyPath = @"C:\TFS-CODE\Thrive\packages\newthrivePrivateKey.ppk";
    }
}
