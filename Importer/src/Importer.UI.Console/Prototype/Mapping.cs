using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype
{
    public class Mapping
    {
        /*
        private string _sourceTableName;
        public string SourceTableName { get { return _sourceTableName; } }

        private string _targetTableName;
        public string TargetTableName { get { return _targetTableName; } }

        private ICollection<ColumnMapping> _columnMappings;
        public ICollection<ColumnMapping> ColumnMappings { get { return _columnMappings; } }

        public Mapping(string sourceTableName, string targetTableName, 
            ICollection<ColumnMapping> columnMappings)
        {
            _sourceTableName = sourceTableName;
            _targetTableName = targetTableName;

            _columnMappings = columnMappings;
        }
        */

        private string _sourceColumnName;
        public string SourceColumnName { get { return _sourceColumnName; } }

        private string _targetColumnName;
        public string TargetTableName { get { return _targetColumnName; } }

        public Mapping(string sourceColumnName, string targetColumnName)
        {
            _sourceColumnName = sourceColumnName;
            _targetColumnName = targetColumnName;
        }
    }
}
