using System.Collections.Generic;

namespace Escyug.Importer.Models
{
    public sealed class DataInstance
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private IEnumerable<Table> _tablesList;
        public IEnumerable<Table> Tables
        {
            get { return _tablesList; }
        }

        internal DataInstance(string connectionString, IEnumerable<Table> tablesList)
        {
            _connectionString = connectionString;
            _tablesList = tablesList;
        }
    }
}
