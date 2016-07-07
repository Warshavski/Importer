using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Processors;

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
            throw new NotImplementedException();

            //SqlConnection conn = new SqlConnection("your connection string here");
            //SqlCommand cmd = new SqlCommand("create table #MyTempTable(Id int, SomeColumn varchar(50))", conn);
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
            //bulkCopy.DestinationTableName = "#MyTempTable";
            //bulkCopy.WriteToServer(dt);
            //conn.Close();
        }

        public Task DeleteDataAsync(IDataReader dataReader, string targetTableName)
        {
            throw new NotImplementedException();
        }
    }
}
