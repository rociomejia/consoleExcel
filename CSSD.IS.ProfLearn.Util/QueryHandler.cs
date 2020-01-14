using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml;
using System.Configuration;

namespace CSSD.IS.ProfLearn.Util

{
    public class QueryHandler : FileHandler
    {
        private static QueryHandler _instance;
        private XmlDocument _doc = null;
        // Lock synchronization object
        private static object _syncLock = new object();

        // Constructor (protected)
        protected QueryHandler()
        {
            string queryFile = AppDomain.CurrentDomain.BaseDirectory + GetAppSettingsFileName("QueryFile");
            
            //string queryFile = GetAppSettingsFileName("QueryFile");
            _doc = new XmlDocument();
            _doc.Load(queryFile);
        }

        public static QueryHandler GetQueryHandler()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new QueryHandler();
                    }
                }
            }
            return _instance;
        }

        public String GetQuery(string id)
        {
            XmlElement root = _doc.DocumentElement;
            XmlElement xmlElememntQuery = (XmlElement)root.SelectSingleNode("query[@id=\"" + id + "\"]");
            return xmlElememntQuery.InnerText;
        }
    }
}
