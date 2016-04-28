using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Escyug.Importer.Data.Metadata;

namespace Escyug.Importer.Data
{
    /// <summary>
    /// Create connection
    /// Create command
    /// </summary>
    public static class DbCommonHelper
    {
        public static DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (DbException)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                        connection = null;
                    throw;
                }
            }
            // Return the connection.
            return connection;
        }

        public static DbCommand CreateCommand(string commandText, DbConnection conn)
        {
            // Assume failure.
            DbCommand command = null;

            if (commandText != null)
            {
                try
                {
                    command = conn.CreateCommand();
                    command.CommandText = commandText;
                    command.CommandType = CommandType.Text;
                }
                catch (DbException)
                {
                    // Set the connection to null if it was created.
                    if (command != null)
                        command = null;
                    throw;
                }
            }
            // Return the command.
            return command;
        }

        public static IDataReader CreateDataReader(string providerName, string connectionString, string commandText)
        {
            DbConnection connection = null;
            IDataReader reader = null;

            try
            {
                connection = DbCommonHelper.CreateDbConnection(providerName, connectionString);

                var command = DbCommonHelper.CreateCommand(commandText, connection);

                connection.Open();

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (DbException ex)
            {
                connection.Close();
                throw ex;
            }

            return reader;
        }

        private static IEnumerable<Column> GetColumnsMetadata(DbConnection connection, string tableName)
        {
            var columnsMetadataList = new List<Column>();

            var columnsSchema = connection.GetSchema("Columns", new string[] { null, null, tableName, null });
            foreach (var columnsSchemaRow in columnsSchema.AsEnumerable())
            {
                var columnName = columnsSchemaRow["COLUMN_NAME"].ToString();
                var columnDataType = columnsSchemaRow["DATA_TYPE"].ToString();

                var columnLength = -1;
                int.TryParse(columnsSchemaRow["CHARACTER_MAXIMUM_LENGTH"].ToString(), out columnLength);

                columnsMetadataList.Add(new Column(columnName, columnDataType, columnLength));
            }

            return columnsMetadataList;
        }

        private static long RowsCount(string tableName, DbConnection connection)
        {
            var commandText = "SELECT COUNT(*) AS TOTAL_ROWS FROM [" + tableName + "]";
            var command = CreateCommand(commandText, connection);
            
            // so stupid
            var count = (long)(int)command.ExecuteScalar();

            return count;
        }

        public static IEnumerable<Table> GetTablesMetadata(string providerName, string connectionString)
        {
            var tablesMetadataList = new List<Table>();

            using (var connection = DbCommonHelper.CreateDbConnection(providerName, connectionString))
            {
                connection.Open();

                var tablesSchema = connection.GetSchema("Tables");
                foreach (var tablesSchemaRow in tablesSchema.AsEnumerable())
                {
                    var tableName = tablesSchemaRow["TABLE_NAME"].ToString();
                    var rowsCount = RowsCount(tableName, connection);

                    var columnsMetadata = GetColumnsMetadata(connection, tableName);

                    tablesMetadataList.Add(new Table(tableName, columnsMetadata, rowsCount));
                }
            }

            return tablesMetadataList;
        }

        // ?? delete ??
        public static bool TestConnection(string providerName, string connectionString)
        {
            try
            {
                DbProviderFactory factory =
                    DbProviderFactories.GetFactory(providerName);

                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                }

                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }

        /* rework this shit
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
        public static DataTable GetData(Table table)
        {
            // create empty DataTable that going to contain table data
            DataTable data = new DataTable();

            // create DbConnection using provider name and connection string 
            using (DbConnection connection = DataAccess.CreateDbConnection(table.ProviderName, table.ConnectionString))
            {
                // create select command text 
                string selectCommandText = string.Format("SELECT * FROM [{0}]", table.Name);

                // open connection
                connection.Open();
                // create DbDatareader
                using (DbDataReader reader = DataAccess.CreateCommand(selectCommandText, connection).ExecuteReader())
                    // load table data from DbDataReader to empty DataTable
                    data.Load(reader);
                // close connection
                connection.Close();
            }

            // return result
            return data;
        }
        */
    }
}
