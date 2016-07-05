using System.Collections.Generic;

namespace Escyug.Importer.Data.Metadata
{
    public sealed class Table
    {
        public string Name { get; private set; }

        public IEnumerable<Column> Columns { get; private set; }

        public long RowsCount { get; private set; }

        public Table(string tableName, IEnumerable<Column> tableColumns)
        {
            Name = tableName;
            Columns = tableColumns;
        }

        public Table(string tableName, IEnumerable<Column> tableColumns, long rowsCount) 
        {
            Name = tableName;
            Columns = tableColumns;
            RowsCount = rowsCount;
        }
    }
}
