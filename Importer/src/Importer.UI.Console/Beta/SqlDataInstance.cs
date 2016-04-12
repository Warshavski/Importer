using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Escyug.Importer.UI.ConsoleApp.Beta
{
    public class SqlDataInstance : IDataInstance
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private ICollection<Table> _tablesCollection;
        public ICollection<Table> Tables
        {
            get { return _tablesCollection; }
        }

        public SqlDataInstance(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            return DbCommonHelper.TestConnection(
                Constants.ProviderName.SQL_PROVIDER, _connectionString);
        }

        // separate class candidate
        private ICollection<Column> CreateColumnsCollection(DbConnection connection, string[] restrictions)
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

        // separate class candidate
        public void Initialize()
        {
            // ?? make a class member instance ??
            using (var connection = DbCommonHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, _connectionString))
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
            }
        }

        public void GetData(int index)
        {
            throw new NotImplementedException();
        }

        public void GetData(string tableName)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Sql instance";
        }
    }
}
