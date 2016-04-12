using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old.Old
{
    public class ColumnMapping
    {
        public string TargetColumnName { get; private set; }
        public string SourceColumnName { get; private set; }

        public ColumnMapping(string targetColumnName, string sourceColumnName)
        {
            TargetColumnName = targetColumnName;
            SourceColumnName = sourceColumnName;
        }
    }
}
