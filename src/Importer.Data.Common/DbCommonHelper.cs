using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using Escyug.Importer.Data.Metadata;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Common
{
    /// <summary>
    /// Create connection
    /// Create command
    /// </summary>
    public static class DbCommonHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static long CountRows(string tableName, DbConnection connection)
        {
            try
            {
                var commandText = "SELECT COUNT(*) AS TOTAL_ROWS FROM [" + tableName + "]";
                var command = CreateCommand(commandText, connection);

                // so stupid
                var count = (long)(int)command.ExecuteScalar();

                return count;
            }
            catch (DbException)
            {
                return -1;
            }
            
        }

        // ?? delete ??
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IEnumerable<Table> GetTablesMetadata(string connectionString, string providerName)
        {
            var tablesMetadataList = new List<Table>();

            using (var connection = DbCommonHelper.CreateDbConnection(providerName, connectionString))
            {
                connection.Open();

                var tablesSchema = connection.GetSchema("Tables");
                foreach (var tablesSchemaRow in tablesSchema.AsEnumerable())
                {
                    var tableName = tablesSchemaRow["TABLE_NAME"].ToString();
                    var rowsCount = DbCommonHelper.CountRows(tableName, connection);

                    var columnsMetadata = GetColumnsMetadata(connection, tableName);

                    tablesMetadataList.Add(new Table(tableName, columnsMetadata, rowsCount));
                }
            }

            return tablesMetadataList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static IEnumerable<Column> GetColumnsMetadata(DbConnection connection, string tableName)
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


        /*---------------------- ASYNC --------------------*/

    }
}
