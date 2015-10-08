using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Engine.Test.Common;
using System.Data.Common;
using System.Data;

namespace Importer.Engine.Test.Files
{
    public abstract class File : IFile
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        private string _providerName;
        public string ProviderName
        {
            get { return _providerName; }
        }

        private List<Table> _tableList;
        public List<Table> TableList
        {
            get { return _tableList; }
        }

        private bool _isSource;
        public bool IsSource
        {
            get { return _isSource; }
        }

        public abstract FileBrowse BrowseType { get; }
        public abstract string Name { get; }

        protected File(string connectionString, string providerName, 
            bool isSource)
        {
            _connectionString = connectionString;
            _providerName = providerName;
            _isSource = isSource;

            InitializeTableList();
        }

        // not a good idea, maybe better to pass List<Table> in constructor
        // TODO : rework (too ugly)
        private void InitializeTableList()
        {
            // initialize link to empty List<SourceTable>
            _tableList = new List<Table>();
            _tableList.Add(Table.EmptyTable);

            // create Sql connection
            using (DbConnection connection = DbFactory.CreateDbConnection(_providerName, _connectionString))
            {
                //open connection
                connection.Open();

                //create and get information about tables from connection schema 
                DataTable dtTablesSchema = connection.GetSchema("Tables");

                foreach (DataRow tablesSchemaRow in dtTablesSchema.Rows)
                {
                    string tableName = tablesSchemaRow["TABLE_NAME"].ToString();

                    List<Column> columnList = new List<Column>();
                    if (_isSource)
                        columnList.Add(Column.EmptyColumn);

                    DataTable dtColumnsSchema = connection.GetSchema("Columns",
                        new string[] { null, null, tableName, null });
    
                    // add new values to List<Column> by initializing each column
                    foreach (DataRow columnsSchemaRow in dtColumnsSchema.Rows)
                    {
                        string columnName = (string)columnsSchemaRow["COLUMN_NAME"];
                        string columnType = columnsSchemaRow["DATA_TYPE"].ToString();
                        int columnLength = -1;
                        int.TryParse(columnsSchemaRow["CHARACTER_MAXIMUM_LENGTH"].ToString(), out columnLength);
                        columnList.Add(new Column(columnName, columnType, columnLength));
                    }

                    _tableList.Add(new Table(tableName, columnList));
                    
                    dtColumnsSchema.Dispose();
                    dtColumnsSchema = null;
                }

                // close connection
                connection.Close();

                // dispose DataTable that contains information about tables
                dtTablesSchema.Dispose();
                dtTablesSchema = null;
            }
        }

        // ??where use .Close() method??
        public bool TestConnection()
        {
            using (DbConnection connection = DbFactory.CreateDbConnection(_providerName, _connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// get data from table 
        /// **********************!!! WARNING NOT SAFE !!!**********************
        /// *                                                                  *
        /// *  if connection to SQl server with server security                *
        /// *  need to add "Persist Security Info=True;" in connection string  *
        /// *                                                                  *
        /// **********************!!! WARNING NOT SAFE !!!**********************
        /// </summary>
        /// <returns>table data</returns>
        public DataTable GetData(string tableName)
        {
            // create empty DataTable that going to contain table data
            DataTable data = new DataTable();

            // create DbConnection using provider name and connection string 
            using (DbConnection connection = DbFactory.CreateDbConnection(_providerName, _connectionString)) 
            {
                // create select command text 
                string selectCommandText = string.Format("SELECT * FROM [{0}]", tableName);

                // open connection
                connection.Open();
                // create DbDatareader
                using (DbDataReader reader = DbFactory.CreateCommand(selectCommandText, connection).ExecuteReader())
                    // load table data from DbDataReader to empty DataTable
                    data.Load(reader);
                // close connection
                connection.Close();
            }

            // return result
            return data;
        }

    }
}
