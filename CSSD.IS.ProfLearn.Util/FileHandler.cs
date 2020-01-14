using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace CSSD.IS.ProfLearn.Util
{
    public class FileHandler
    {
        protected string GetAppSettingsFileName(string keyInAppSettings)
        {
            string fileName = ConfigurationManager.AppSettings.Get(keyInAppSettings);
            return fileName;
        }
    }
}
