using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Beta
{
    public interface IDataInstance
    {
        string ConnectionString { get; set; }

        ICollection<Table> Tables { get; }

        bool TestConnection();

        void Initialize();
        void GetData(int index);
        void GetData(string tableName);
    }
}
