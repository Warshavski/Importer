using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Test.Files
{
    internal class SqlFile : File
    {
        private const string PROVIDER_NAME = ""; // m.b. pass it in constructor
        private const FileBrowse BROWSE_TYPE = FileBrowse.None; // m.b. pass it in constructor

        internal SqlFile(string connectionString, bool isSource)
            : base(connectionString, PROVIDER_NAME, isSource, BROWSE_TYPE)
        { 
            
        }

        //some operations for SQL Files only
    }
}
