using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Test.Files
{
    internal class DbfFile : File
    {
        private const string PROVIDER_NAME = "";
        private const FileBrowse BROWSE_TYPE = FileBrowse.Folder;

        internal DbfFile(string connectionString, bool isSource)
            : base(connectionString, PROVIDER_NAME, isSource, BROWSE_TYPE)
        { 
            
        }
        
        // Some operations for dbf files only
    }
}
