using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Engine.Test.Common;
using System.Data;

namespace Importer.Engine.Test.Files
{
    // How file shall be open
    public enum FileBrowse { None, File, Folder };

    public interface IFile
    {
        string ConnectionString { get; }
        string ProviderName { get; }
        bool IsSource { get; }
        List<Table> TableList { get; }

        bool TestConnection();
        DataTable GetData(string tableName);
    }
}
