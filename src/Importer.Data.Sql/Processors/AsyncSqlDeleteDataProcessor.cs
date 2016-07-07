using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;
using System.Data.SqlClient;

namespace Escyug.Importer.Data.Sql.Processors
{
    public class AsyncSqlDeleteDataProcessor : SqlProcessor,
        IAsyncDeleteDataProcessor
    {
        public async Task DeleteDataAsync(IDataReader dataReader, string targetTableName, string targetConnectionString)
        {
            //dataReader.
            //var tempTableName = "#Temp" + targetTableName;
            //var createTempTableCommnadText = "create table #MyTempTable(Id int, SomeColumn varchar(50))"
            //using (var connection = DbCommonHelper.CreateDbConnection(
            //    PROVIDER_NAME, targetConnectionString))
            //{
            //    using (var createTempTableCommand = DbCommonHelper.CreateDbConnection)
            //}
           
            //SqlConnection conn = new SqlConnection("your connection string here");
            //SqlCommand cmd = new SqlCommand("create table #MyTempTable(Id int, SomeColumn varchar(50))", conn);
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
            //bulkCopy.DestinationTableName = "#MyTempTable";
            //bulkCopy.WriteToServer(dt);
            //conn.Close();

            var tempTableName = "#Temp" + targetTableName;
            var createTempTableCommnadText = "create table " + tempTableName + "(EAN13 varchar(50))";
            var deleteDataCommandText = "delete from " + targetTableName + " where EAN13 in (select EAN13 from " + tempTableName + ");";

            using (var connection = DbCommonHelper.CreateDbConnection(
                PROVIDER_NAME, targetConnectionString))
            {
                await connection.OpenAsync();

                using (var createTempTableCommand = DbCommonHelper.CreateCommand(
                    createTempTableCommnadText, connection))
                {
                    await createTempTableCommand.ExecuteNonQueryAsync();
                }

                using (var bulkCopy = new SqlBulkCopy((SqlConnection)connection))
                {
                    bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("EAN13", "EAN13"));
                    bulkCopy.DestinationTableName = tempTableName;
                    bulkCopy.BulkCopyTimeout = 1800;
                    
                    await bulkCopy.WriteToServerAsync(dataReader);
                }

                using (var deleteDataCommand = DbCommonHelper.CreateCommand(
                    deleteDataCommandText, connection))
                {
                    await deleteDataCommand.ExecuteNonQueryAsync();
                }
            }
        }

        public Task DeleteDataAsync(IDataReader dataReader, string targetTableName)
        {
            throw new NotImplementedException();
        }
    }
}
