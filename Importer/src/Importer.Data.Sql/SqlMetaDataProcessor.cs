using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Escyug.Importer.Data.Entities;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.Sql
{
    // same class implementation in OleDbMetaDataProcessor (different connections)
    public class SqlMetaDataProcessor : IMetaDataProcessor
    {
        private IEnumerable<Column> SelectColumnsMetaData(SqlConnection connection, string tableName)
        {
            var columnsMetaDataList = new List<Column>();

            var columnsSchema = connection.GetSchema("Columns", new string[] { null, null, tableName, null });
            foreach (var columnsSchemaRow in columnsSchema.AsEnumerable())
            {
                var columnName = columnsSchemaRow["COLUMN_NAME"].ToString();
                var columnDataType = columnsSchemaRow["DATA_TYPE"].ToString();

                var columnLength = -1;
                int.TryParse(columnsSchemaRow["CHARACTER_MAXIMUM_LENGTH"].ToString(), out columnLength);

                columnsMetaDataList.Add(new Column(columnName, columnDataType, columnLength));
            }

            return columnsMetaDataList;
        }

        private IEnumerable<Table> SelectTablesMetaData(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> SelectTablesMetaData(string connectionString)
        {
            var tablesMetaDataList = new List<Table>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tablesSchema = connection.GetSchema("Tables");
                foreach (var tablesSchemaRow in tablesSchema.AsEnumerable())
                {
                    var tableName = tablesSchemaRow["TABLE_NAME"].ToString();
                    
                    var columnsMetaData = SelectColumnsMetaData(connection, tableName);

                    tablesMetaDataList.Add(new Table(tableName, columnsMetaData));
                }
            }

            return tablesMetaDataList;
        }
    }
}
