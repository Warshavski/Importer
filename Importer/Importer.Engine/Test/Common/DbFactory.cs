using System.Data;
using System.Data.Common;

namespace Importer.Engine.Test.Common
{
    /// <summary>
    /// Create connection
    /// Create command
    /// </summary>
    internal static class DbFactory
    {
        internal static DbConnection CreateDbConnection(string providerName, string connectionString)
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
                }
            }
            // Return the connection.
            return connection;
        }

        internal static DbCommand CreateCommand(string commandText, DbConnection conn)
        {
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
                    {
                        command = null;
                    }
                    //Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return command;
        }
    }
}
