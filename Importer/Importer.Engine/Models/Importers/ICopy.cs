using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Models.Importers
{
    public delegate void CopyProgress(long rowsCopied, long rowsTotal);

    public struct ColumnsMapping
    {
        private string _sourceColumn;
        public string SourceColumn
        {
            get { return _sourceColumn; }
        }

        private string _targerColumn;
        public string TargetColumn
        {
            get { return _targerColumn; }
        }

        public ColumnsMapping(string sourceColumn, string targetColumn)
        {
            _sourceColumn = sourceColumn;
            _targerColumn = targetColumn;
        }
    }

    public interface ICopy
    {

    }
}
