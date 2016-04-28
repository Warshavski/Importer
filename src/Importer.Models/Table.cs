using System;
using System.Collections.Generic;

namespace Escyug.Importer.Models
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

        public bool IsForImport { get; set; }
        public string MappedTableName { get; set; }

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

        public override string ToString()
        {
            return _tableName;
        }
    }
}
