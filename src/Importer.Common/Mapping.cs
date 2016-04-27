using System.Collections.Generic;

namespace Escyug.Importer.Common
{
    public class Mapping
    {
        private string _sourceTableName;
        public string SourceTable { get { return _sourceTableName; } }

        private string _targetTableName;
        public string TargetTableName { get { return _targetTableName; } }

        private IEnumerable<ColumnsMapping> _columnsMappings;
        public IEnumerable<ColumnsMapping> ColumnsMapping { get { return _columnsMappings; } }

        public Mapping(string sourceTableName, string targetTableName, 
            IEnumerable<ColumnsMapping> columnsMappings)
        {
            _sourceTableName = sourceTableName;
            _targetTableName = targetTableName;
            _columnsMappings = columnsMappings;
        }
    }
}
