using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    public class Table
    {
        public string Name { get; private set; }
        
        public ICollection<Column> Columns { get; private set; }

        public bool IsForImport { get; set; }

        public string MappingTableName { get; set; }

        public Table(string name, ICollection<Column> columns)
        {
            Name = name;
            Columns = columns;
            IsForImport = false;
        }
    }
}
