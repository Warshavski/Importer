using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Entities;

namespace Escyug.Importer.Data.Sql.QueryProcessors
{
    public class SelectTablesQueryProcessor 
    {
        private IEnumerable<Column> CreateColumns(DataTable columnsSchema)
        {
            var columnsList = new List<Column>();
            foreach (DataRow schemaRow in columnsSchema.Rows)
            {
                var columnName = schemaRow["COLUMN_NAME"].ToString();
                var columnType = schemaRow["DATA_TYPE"].ToString();

                int columnLength = -1;
                int.TryParse(schemaRow["CHARACTER_MAXIMUM_LENGTH"].ToString(), out columnLength);

                columnsList.Add(new Column(columnName, columnType, columnLength));
            }

            return columnsList;
        }

        // #REWRITE : too ugly
        public IEnumerable<Table> SelectTables(string connectionString)
        {
            var tablesList = new List<Table>();

            using (var connection = DbCommonHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, connectionString))
            {
                connection.Open();

                var tablesSchema = connection.GetSchema("Tables");
                foreach (DataRow tablesSchemaRow in tablesSchema.Rows)
                {
                    var tableName = tablesSchemaRow["TABLE_NAME"].ToString();

                    var restrictions = new string[4];
                    restrictions[2] = tableName;

                    var columnsSchema = connection.GetSchema("Columns", restrictions);

                    var columns = CreateColumns(columnsSchema);

                    tablesList.Add(new Table(tableName, columns));
                }  
            }

            return tablesList;
        }
    }
}
