using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Importer.Engine.Models
{
    internal class ExcelFile : IFile
    {
        private const string PROVIDER_NAME = "System.Data.OleDb";

        internal ExcelFile(string filePath, PropertyInfo property)
        {
            // initialize base class connection string 
            _connectionString = string.Format(
              @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties={1}; ",
              filePath, property.Value);

            _tableList = null;
        }

        #region Члены IFile

        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        private IList<Table> _tableList = null;
        public IList<Table> TableList
        {
            get { return _tableList; }
        }

        public bool TestConnection()
        {
            using (var connection = new OleDbConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (DbException)
                {
                    return false;
                }
            }
        }

        public void InitializeTables(bool isSource)
        {
            // create OleDb connection
            using (DbConnection connection = CommonData.CreateDbConnection(PROVIDER_NAME, _connectionString))
            {
                // create link to empty List<SourceTable>
                _tableList = new List<Table>();

                connection.Open();
                // get information about tables from connection schema
                DataTable dtTables = connection.GetSchema("Tables");
                // initialization of OleDbTable class and add it into table collection
                foreach (DataRow dtTablesRow in dtTables.Rows)
                    _tableList.Add(new Table((string)dtTablesRow["TABLE_NAME"], connection, PROVIDER_NAME, isSource));
                connection.Close();

                // disposing DataTable that contains information about tables
                dtTables.Dispose();
                dtTables = null;
            }
        }

        #endregion
    }
}
