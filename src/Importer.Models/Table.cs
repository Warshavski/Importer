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

        private bool _isForImport;
        public bool IsForImport
        {
            get { return _isForImport; }
            set { _isForImport = value; }
        }

        private string _mappedTableName;
        public string MappedTableName
        {
            get { return _mappedTableName; }
            set { _mappedTableName = value; }
        }

        internal Table(string tableName, IEnumerable<Column> tableColumns) 
        {
            _tableName = tableName;
            _tableColumns = tableColumns;
            _isForImport = false;
        }

        public override string ToString()
        {
            return _tableName;
        }
    }
}
