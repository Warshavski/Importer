using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Importer.Engine.Test.Common
{
    public class Table
    {
        private const string EMPTY_NAME = "empty data";

        // Empty column value
        private static readonly Table _emptyTable = new Table(EMPTY_NAME, null);
        public static Table EmptyTable
        {
            get
            {
                return _emptyTable;
            }
        }

        private string _tableName;
        public string Name
        {
            get { return _tableName; }
        }

        private List<Column> _columnList;


        internal Table(string tableName, List<Column> columnList)
        {
            _tableName = tableName;
            _columnList = columnList;
        }
    }
}
