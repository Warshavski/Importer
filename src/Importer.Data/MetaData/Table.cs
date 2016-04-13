using System.Collections.Generic;

namespace Escyug.Importer.Data.MetaData
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

        public Table(string tableName, IEnumerable<Column> tableColumns) 
        {
            _tableName = tableName;
            _tableColumns = tableColumns;
        }
    }
}
