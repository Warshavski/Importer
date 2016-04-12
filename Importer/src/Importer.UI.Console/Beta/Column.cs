using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Beta
{
    public sealed class Column
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Lenght { get; private set; }

        // ?? bool IsForImport ??
        public bool IsForImport { get; set; }

        public string MappingColumnName { get; set; }

        public Column(string name, string type, int lenght)
        {
            Name = name;
            Type = type;
            Lenght = lenght;
        }
    }
}
