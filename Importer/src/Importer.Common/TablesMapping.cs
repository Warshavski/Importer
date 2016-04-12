
namespace Escyug.Importer.Common
{
    public class TablesMapping
    {
        private string _sourceTableName;
        public string SourceTableName
        {
            get { return _sourceTableName; }
        }

        private string _targetTableName;
        public string TargetTableName
        {
            get { return _targetTableName; }
        }

        public TablesMapping(string sourceTableName, string targetTableName)
        {
            _sourceTableName = sourceTableName;
            _targetTableName = targetTableName;
        }
    }
}
