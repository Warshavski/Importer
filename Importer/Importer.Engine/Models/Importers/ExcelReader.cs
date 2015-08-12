using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Importer.Engine.Models.Importers
{
    public class ExcelReader
    {
        private string _connectionString = string.Empty;
        private DbConnection _excelConnection = null;

        readonly Func<string, object>[] _convertTable;
        readonly Func<string, bool>[] _constraintsTable;

        private string[] _currentLineValues;
        private string _currentLine;


        public ExcelReader(string connectionString)
        {
            _connectionString = connectionString;
            
        }

        public ExcelReader(string filepath, Func<string, bool>[] constraintsTable, Func<string, object>[] convertTable)
        {
            _constraintsTable = constraintsTable;
            _convertTable = convertTable;

            string commandText = string.Format("select * from [{0}] ", "JNVLP");

            _excelConnection = DataAccess.CreateDbConnection("System.Data.OleDb", filepath);

            using (DbDataReader reader = DataAccess.CreateCommand(commandText, _excelConnection).ExecuteReader())
            {
                reader.GetValue(0);

            }

            _currentLine = null;
            _currentLineValues = null;
        }
    }
}
