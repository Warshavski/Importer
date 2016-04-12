using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    /**
     * TODO : 
     *  1. Create separate classes with helper methods with common interfaces (for DI).
     */

    public abstract class GenericInstance
    {
         #region Properties

        //private const string PROVIDER_NAME = "System.Data.Sqlclient";
        public abstract string ProviderName { get; }

        protected string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        protected ICollection<Table> _tablesCollection;
        public  ICollection<Table> Tables
        {
            get { return _tablesCollection; }
        }


        #endregion
        

        #region Helper methods

        /* use for source select command (need for IDataReader instance creation) */
        protected string ConstructSelectCommand(Table table)
        {
            StringBuilder commnadTextBuilder = new StringBuilder("SELECT ");

            foreach (var column in table.Columns)
            {
                if (column.IsForImport)
                    commnadTextBuilder.AppendFormat("{0},", column.Name);
            }

            // removes last ',' sign
            commnadTextBuilder.Remove(commnadTextBuilder.Length - 1, 1);

            commnadTextBuilder.AppendFormat(" FROM dbo.[{0}]", table.Name);

            return commnadTextBuilder.ToString();
        }

        protected ICollection<Column> CreateColumnsCollection(DbConnection connection, string[] restrictions)
        {
            // get column schema of specific table
            var columnSchemas = connection.GetSchema("Columns", restrictions);

            var columnsCollection = new List<Column>();
            foreach (DataRow columSchemasRow in columnSchemas.Rows)
            {
                var columnName = columSchemasRow["COLUMN_NAME"].ToString();
                var columnType = columSchemasRow["DATA_TYPE"].ToString();

                columnsCollection.Add(new Column(columnName, columnType, -1));
            }

            return columnsCollection;
        }

        /** Creates list of Mapping class which contains mapping between columns 
         *  (source and target)
         * TODO : 
         *  1. Decide what gonna be source and target.
         */
        protected IEnumerable<Mapping> ExtractColumnMappings(Table table)
        {
            var columnMappings = new List<Mapping>();
            foreach (var column in table.Columns)
            {
                if (column.IsForImport)
                {
                    columnMappings.Add(
                        new Mapping(column.Name, column.MappingColumnName));
                }
            }

            return columnMappings;
        }

        #endregion

        /** initialize Table collection of instance
         * TODO :
         *  1. Create separate class with constants (remove all magic numbers and strings)
         */
        public void Initialize()
        {
            // ?? make a class member instance ??
            using (var connection = DbAccessHelper.CreateDbConnection(ProviderName, _connectionString))
            {
                connection.Open();

                var restrictions = new string[4];

                // get table schemas
                var tableSchemas = connection.GetSchema("Tables");

                _tablesCollection = new List<Table>();
                foreach (DataRow tableSchemasRow in tableSchemas.Rows)
                {
                    var tableName = tableSchemasRow["TABLE_NAME"].ToString();

                    restrictions[2] = tableName;
                    var columnsCollection = CreateColumnsCollection(connection, restrictions);

                    _tablesCollection.Add(new Table(tableName, columnsCollection));
                }

                connection.Close();
            }
        }

        public DataTable GetData(Table table)
        {
            throw new NotImplementedException();
        }

        public bool TestConnection()
        {
            try
            {
                DbProviderFactory factory = 
                    DbProviderFactories.GetFactory(ProviderName);

                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                }

                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
    }
}
