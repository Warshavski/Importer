using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Test.Files
{
    //have no idea why this class exists

    //?? if we have a dictionary do we need an a enum ??
    //public enum FileType { Excel, Dbf, Sql };
    
    public class FileFactory
    {   
        //?? create separate class for providers like PropertyInfo
        private Dictionary<string, string> _dbProviders;
        public Dictionary<string, string> ProvidersList
        {
            get { return _dbProviders; }
        }

        public FileFactory()
        {
            _dbProviders = new Dictionary<string, string>()
            {
                {"Excel", "System.Data.OleDb"},
                {"Dbf", "System.Data.OleDb"},
                {"Sql", "System.Data.SqlClient"}
            };
        }

        public File Create(string connectionString, string providerName, bool isSource)
        {
            return new File(connectionString, providerName, isSource);
        }
    }
}
