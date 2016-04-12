using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    public sealed class SqlInstance : GenericInstance, IImportable
    {
        #region Properties

        public override string ProviderName
        {
            get { return Constants.ProviderName.SQL_PROVIDER; }
        }

        #endregion

        public event Action<string> ImportStatusChanged;

        public SqlInstance(string connectionString) 
        {
            base._connectionString = connectionString;
        }

        public void ImportData(GenericInstance source, bool isTruncate) 
        {
            using (var connection = DbAccessHelper.CreateDbConnection(
               source.ProviderName, source.ConnectionString))
            {
                connection.Open();

                foreach (var table in source.Tables)
                {
                    if (!table.IsForImport)
                        continue;

                    var mappings = ExtractColumnMappings(table);

                    var selectCommandText = ConstructSelectCommand(table);
                    var selectCommand = DbAccessHelper.CreateCommand(selectCommandText, connection);

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        var importer = new SqlImporter(reader);
                        importer.StatusUpdated += ImportStatusChanged;
                        importer.TargetConnectionString = base._connectionString;
                        importer.TargetTableName = table.MappingTableName;
                        importer.Mappings = mappings;

                        importer.Import(isTruncate);
                    }
                }

                connection.Close();
            }
        }
    }
}





//using (var connection = new SqlConnection(source.ConnectionString))
//{
//    connection.Open();

//    foreach (var table in _tablesCollection)
//    {
//        if (!table.IsForImport)
//            continue;

//        var mappings = ExtractColumnMappings(table);

//        var selectCommandText = ConstructSelectCommand(table);
//        using (var reader = new SqlDataReader()) 
//        {
//            var importer = new SqlImporter(reader);

//            importer.Mappings = mappings;
//            importer.TargetConnectionString = table.Name;
//            importer.TargetConnectionString = _connectionString;
//        }
//    }
//}

/* old version of Initialize()
var tableCollection = new List<Table>();
_mappings = new List<Mapping>();

using (SqlConnection connection = new SqlConnection(_connectionString))
{
    connection.Open();

    var tableSchemas = connection.GetSchema("Tables");
    string[] restrictions = new string[4];


    foreach (DataRow tableSchemasRow in tableSchemas.Rows)
    {
        // get all tables schemas
        var tableName = tableSchemasRow["TABLE_NAME"].ToString();

        restrictions[2] = tableName;

        var columnSchemas = connection.GetSchema("Columns", restrictions);
        var columnCollection = new List<Column>();
        var columnMappings = new List<ColumnMapping>();
        foreach (DataRow columnSchemasRow in columnSchemas.Rows)
        {
            var columnName = columnSchemasRow["COLUMN_NAME"].ToString();
            var columnType = columnSchemasRow["DATA_TYPE"].ToString();

            columnCollection.Add(new Column(columnName, columnType, -1));
            columnMappings.Add(new ColumnMapping(columnName, columnName));
        }

        _mappings.Add(new Mapping(tableName, tableName, columnMappings));

        //clear columnSchemas 
        tableCollection.Add(new Table(tableName, columnCollection));
    }

    //clear tableSchemas 

    connection.Close();
}
*/

/* old version of Import() 
 *  public void ImportData()
        {
            IImportable target = this;
            //ICollection<Mapping> mappings
            //var selectCommandText = ConstructSelectCommand(tableForImport);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var map in _mappings)
                {
                    var sourceTableName = map.SourceTableName;
                    var targetTableName = map.TargetTableName;

                    var sourceColumnNamesList = new List<string>();
                    foreach (var elem in map.ColumnMappings)
                        sourceColumnNamesList.Add(elem.SourceColumnName);

                    var selectCommandText = ConstructSelectCommand(sourceTableName, sourceColumnNamesList);
                    using (var reader = new SqlCommand(selectCommandText, connection).ExecuteReader())
                    {
                        var importer = new SqlImporter(reader);
                        importer.TargetConnectionString = @"Server=tcp:escyug.database.windows.net,1433;Database=lissMerged;User ID=escyug@escyug;Password=pgpFmvk5;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                        importer.TargetTableName = "testImport";
                        importer.Mapping = map;
                        importer.RowsCopied += (obj) => Notify(string.Format("rows copied: {0}\n", obj.ToString()));
                        // try to use truncate option while self-import
                        Notify(string.Format("Importing {0} ....", sourceTableName));
                        importer.Import(false);
                        Notify(string.Format("{0}{1}", "Done", Environment.NewLine));
                    }
                }
            }
            // create IDataReader 
            // create SqlImporter
            // call SqlImporter.Import()
        }
 */