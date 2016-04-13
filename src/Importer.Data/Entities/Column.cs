﻿namespace Escyug.Importer.Data.Entities
{
    public class Column
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

        public Column(string columnName, string columnType, int columnLength) 
        {
            _columnName = columnName;
            _columnType = columnType;
            _columnLength = columnLength;
        }
    }
}