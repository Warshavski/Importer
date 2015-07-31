using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Importer.Engine.Models
{
    /* TODO : 
     *  1. - done - Create one class for table collection)
     *  2. Exclude GetData method
     *  3. - done - Allocate a separate method for columns list initialization
     */

    /// <summary>
    /// class that contains information about table
    /// </summary>
    public class Table
    {
        #region Properties

        // name of data provider 
        private string _providerName = string.Empty;
        public string ProviderName
        {
            get
            {
                return _providerName;
            }
        }

        // connection string
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        // column collection of each table
        // initialized in specific implementation of that class
        protected IList<Column> _columnList = null;
        public IList<Column> Columns
        {
            get 
            { 
                return _columnList; 
            }
        }

        // name of each table 
        // initialized in specific class constructor
        private string _tableName = string.Empty;
        public string Name
        {
            get 
            { 
                return _tableName; 
            }
        }

        // if table is in source file (need for adding skip column)
        private bool _isSourceTable = false;
        public bool IsSourceTable
        {
            get 
            { 
                return _isSourceTable; 
            }
            set 
            {
                _isSourceTable = value;
            }
        }
        
        // total rows in table (change magical literal on constant)
        private int _rowsCount = -1;
        public int RowsCount
        {
            get
            {
                if (_rowsCount == -1)
                {
                    _rowsCount = GetRowsCount(this._tableName);
                    return _rowsCount;
                }
                else
                {
                    return _rowsCount;
                }
            }
        }

        #endregion

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="tableName">name of table</param>
        /// <param name="connection">the connection which we get from Schema</param>
        /// <param name="providetName">name of data provider</param>
        /// <param name="isSourceTable">is table in source file</param>
        internal Table(string tableName, DbConnection connection, string providerName, bool isSourceTable)
        {
            // initialize class data fields
            _tableName = tableName;
            _connectionString = connection.ConnectionString;
            _providerName = providerName;
            _isSourceTable = isSourceTable;

            InitializeColumns(connection);
        }

        /// <summary>
        /// Initialze columns
        /// </summary>
        /// <param name="connection">DbConnection</param>
        private void InitializeColumns(DbConnection connection)
        {
            // create new link to empty List<Column>
            _columnList = new List<Column>();

            // get information about columns for this table
            // use second parameter string array
            DataTable dtColumns = connection.GetSchema("Columns",
                new string[] { null, null, _tableName, null });

            // column index
            int index = 0;
            // if column in source file
            if (_isSourceTable)
                // add first column as empty column
                _columnList.Add(new Column(Column.EmptyColumn, index));

            // add new values to List<Column> by initializing each column
            foreach (DataRow dtColumnsRow in dtColumns.Rows)
            {
                _columnList.Add(new Column((string)dtColumnsRow["COLUMN_NAME"], index));
                ++index;
            }

            // dispose DataTable that contains columns information
            dtColumns.Dispose();
            dtColumns = null;
        }

        /// <summary>
        /// get total rows in table (closed method used in property)
        /// </summary>
        /// <param name="tableName">name of table</param>
        /// <returns>rows count</returns>
        private int GetRowsCount(string tableName)
        {
            // create variable for query result
            int count = 0;
            // create commnad text for query
            string commandText = string.Format("SELECT COUNT(*) FROM [{0}]", tableName);
            
            // create db connection
            using (DbConnection dbConnection = CommonData.CreateDbConnection(_providerName, _connectionString))
            {
                // create command 
                using (DbCommand command = CommonData.CreateCommand(commandText, dbConnection))
                {
                    // open db connectiom
                    dbConnection.Open();
                    // execute query
                    count = (int)command.ExecuteScalar();
                }
                // close db connection
                dbConnection.Close();
            }
            // return result
            return count;
        }

        /*!!!Exclude this method!!!*/
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
        public DataTable GetData()
        {
            // create empty DataTable that going to contain table data
            DataTable data = new DataTable();

            // create DbConnection using provider name and connection string 
            using (DbConnection connection = CommonData.CreateDbConnection(_providerName, _connectionString))
            {
                // create select command text 
                string selectCommandText = string.Format(
                    "SELECT * FROM [{0}]", _tableName);

                // open connection
                connection.Open();
                // create DbDatareader
                using (DbDataReader reader = CommonData.CreateCommand(selectCommandText, connection).ExecuteReader())
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
