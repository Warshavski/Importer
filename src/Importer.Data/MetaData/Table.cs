using System.Collections.Generic;

namespace Escyug.Importer.Data.Metadata
{
    public sealed class Table
    {
        private string _tableName;
        public string Name
        {
            get { return _tableName; }
        }

        private IEnumerable<Column> _tableColumns;
        public IEnumerable<Column> Columns
        {
            get { return _tableColumns; }
        }

        private long _rowsCount;
        public long RowsCount
        {
            get { return _rowsCount; }
        }

        internal Table(string tableName, IEnumerable<Column> tableColumns)
        {
            _tableName = tableName;
            _tableColumns = tableColumns;
        }

        internal Table(string tableName, IEnumerable<Column> tableColumns, long rowsCount) 
        {
            _tableName = tableName;
            _tableColumns = tableColumns;
            _rowsCount = rowsCount;
        }
    }
}
