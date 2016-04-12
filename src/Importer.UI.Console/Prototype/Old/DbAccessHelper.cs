using System.Data;
using System.Data.Common;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    /// <summary>
    /// Create connection
    /// Create command
    /// </summary>
    public static class DbAccessHelper
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
