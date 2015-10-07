using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Test.Common
{
    public class Column
    {
        private const string EMPTY_NAME = "empty data";
        private const string EMPTY_DATA_TYPE = "empty data";
        private const int EMPTY_LENGTH = -1;

        // Empty column value
        private static readonly Column _emptyColumn = new Column(EMPTY_NAME, EMPTY_DATA_TYPE, EMPTY_LENGTH);
        public static Column EmptyColumn
        {
            get
            {
                return _emptyColumn;
            }
        }

        private string _columnName;
        public string Name
        {
            get { return _columnName; }
        }

        private string _columnType;
        public string Type
        {
            get { return _columnType; }
        }

        
        private int _columnLenght;
        public int Lenght
        {
            get { return _columnLenght; }
        }

        internal Column(string columnName, string columnType, int columnLenght)
        {
            _columnName = columnName;
            _columnType = columnType;
            _columnLenght = columnLenght;
        }
    }
}
