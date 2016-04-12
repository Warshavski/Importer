using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

using Escyug.Importer.Data.Entities;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb
{
    // same class implementation in SqlMetaDataProcessor (different connections)
    public class OleDbMetaDataProcessor : IMetaDataProcessor
    {
        private IEnumerable<Column> SelectColumnsMetaData(OleDbConnection connection, string tableName)
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

        private IEnumerable<Table> SelectTablesMetaData(OleDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Table> SelectTablesMetaData(string connectionString)
        {
            var tablesMetaDataList = new List<Table>();

            using (var connection = new OleDbConnection(connectionString))
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
