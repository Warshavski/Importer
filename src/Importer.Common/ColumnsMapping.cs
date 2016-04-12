namespace Escyug.Importer.Common
{
    public class ColumnsMapping
    {
        private string _sourceColumnName;
        public string SourceColumnName
        {
            get { return _sourceColumnName; }
        }

        private string _targetColumnName;
        public string TargetColunmName
        {
            get { return _targetColumnName; }
        }

        public ColumnsMapping(string sourceColumnName, string targetColumnName)
        {
            _sourceColumnName = sourceColumnName;
            _targetColumnName = targetColumnName;
        }
    }
}
