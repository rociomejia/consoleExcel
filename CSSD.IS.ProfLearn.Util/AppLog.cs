using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Reflection;


namespace CSSD.IS.ProfLearn.Util
{
    public class AppLog
    {
        public const string LOG_FILE = "LogFile";

        private static AppLog _Instance;        
        private string _AppLogFileName;
        // Lock synchronization object
        private static object _SyncLock = new object();

        protected AppLog()
        {
            SetAppLogFileName(LOG_FILE);            
            HasError = false;
        }

        private bool _hasError;

        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        public static AppLog GetAppLog()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_Instance == null)
            {
                lock (_SyncLock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new AppLog();
                    }
                }
            }
            return _Instance;
        }

        public void Log(string value)
        {
            StreamWriter _AppLogStream = File.AppendText(_AppLogFileName);
            _AppLogStream.Write("\r\nLog Entry : ");
            _AppLogStream.WriteLine(String.Format("{0:yyyy-MM-dd:HH:mm:ss} ", DateTime.Now) + ":");
            _AppLogStream.WriteLine(value);
            _AppLogStream.WriteLine("-------------------------------");
            _AppLogStream.Flush();
            _AppLogStream.Close();
        }
        
        public void SetAppLogFileName(string keyInAppSettings)
        {
            string currentDateTime = String.Format("{0:yyyy_MM_dd}", DateTime.Now);
            _AppLogFileName = ConfigurationManager.AppSettings.Get(keyInAppSettings);
            string filePath = Path.GetDirectoryName(_AppLogFileName) + "\\";
            if (_AppLogFileName.StartsWith("."))
            {
                string executableFile = Assembly.GetExecutingAssembly().Location;
                string executablePath = Path.GetDirectoryName(executableFile);
                if (!executablePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    executablePath += Path.DirectorySeparatorChar;
                }

                filePath = filePath.Trim('.').TrimStart(Path.DirectorySeparatorChar);
                executablePath += filePath;
                if (!executablePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    executablePath += Path.DirectorySeparatorChar;
                }

                if (!Directory.Exists(executablePath))
                {
                    Directory.CreateDirectory(executablePath);
                }


                _AppLogFileName = executablePath
                                    + Path.GetFileNameWithoutExtension(_AppLogFileName)
                                    + "_" + currentDateTime
                                    + Path.GetExtension(_AppLogFileName);
            }
            else
            {
                _AppLogFileName = filePath
                                   + Path.GetFileNameWithoutExtension(_AppLogFileName)
                                   + "_" + currentDateTime
                                   + Path.GetExtension(_AppLogFileName);
            }
        }

        public string GetAppLogFileName()
        {
            return _AppLogFileName;
        }       
    }
}
