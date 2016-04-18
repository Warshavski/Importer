namespace Escyug.Importer.Models
{
    public sealed class Column
    {
        private string _columnName;
        public string Name
        {
            get { return _columnName; }
        }

        private string _columnType; // ?? object ??
        public string Type
        {
            get { return _columnType; }
        }

        private int _columnLength;
        public int Length
        {
            get { return _columnLength; }
        }

        private bool _isForImport;
        public bool IsForImport
        {
            get { return _isForImport; }
            set { _isForImport = value; }
        }

        private string _mappedColumnName;
        public string MappedColumnName
        {
            get { return _mappedColumnName; }
            set { _mappedColumnName = value; }
        }

        internal Column(string columnName, string columnType, int columnLength) 
        {
            _columnName = columnName;
            _columnType = columnType;
            _columnLength = columnLength;
            _isForImport = false;
        }
    }
}
