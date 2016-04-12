using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    public interface IDataInstance
    {
        IEnumerable<Table> Tables { get; }

        void Initialize();
        void TestConnection();
        void GetData(int index);
        void GetData(string tableName);
    }
}
