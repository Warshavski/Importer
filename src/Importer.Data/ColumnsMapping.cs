using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data
{
    public sealed class ColumnsMapping
    {
        public string SourceColumnName { get; private set; }
        public string DestinationColumnName { get; private set; }

        public ColumnsMapping(string sourceColumnName, string destinationColumnName)
        {
            SourceColumnName = sourceColumnName;
            DestinationColumnName = destinationColumnName;
        }
    }
}
