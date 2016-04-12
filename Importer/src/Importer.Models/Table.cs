using System;
using System.Collections.Generic;

namespace Escyug.Importer.Models
{
    public class Table
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
        }

        public Table(string tableName, IEnumerable<Column> tableColumns) 
        {
            _tableName = tableName;
            _tableColumns = tableColumns;
            _isForImport = false;
        }

        public void MarkForImport()
        {
            _isForImport = true;
        }

        public void SetMappings()
        {
            throw new NotImplementedException();
        }
    }
}
