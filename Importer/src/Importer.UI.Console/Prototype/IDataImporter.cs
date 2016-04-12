using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype
{
    // i don't why i use generic interface (m.b. this is cool)
    public interface IDataImporter<TDataReader, TMapping> : IDisposable
    {
        void Copy(string targetTableName, TDataReader sourceReader, IEnumerable<TMapping> mappings);
    }
}
