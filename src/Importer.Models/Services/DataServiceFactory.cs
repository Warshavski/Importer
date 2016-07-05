using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql.Processors;
using Escyug.Importer.Data.OleDb.Processors;

namespace Escyug.Importer.Models.Services
{
    public enum DataServicesTypes
    {
        OleDb,
        Sql,
        Xml
    }

    public class DataServiceFactory
    {
        private static Dictionary<DataServicesTypes, Func<string, IDataService>> _dataServicesCreators =
            new Dictionary<DataServicesTypes, Func<string, IDataService>>()
            {
                { DataServicesTypes.OleDb, CreateOleDbDataService },
                { DataServicesTypes.Sql, CreateSqlDataService }
            };


        public static IDataService Create(DataServicesTypes serviceType, string connectionString)
        {
            return _dataServicesCreators[serviceType].Invoke(connectionString);
        }

        private static IDataService CreateSqlDataService(string connectionString)
        {
            var importProcessor = new SqlDataImportProcessor();
            var dataReaderProcessor = new SqlDataReaderProcessor();
            var metadataProcessor = new SqlMetadataProcessor();

            var sqlDataService = new DataService(connectionString,
                metadataProcessor, importProcessor, dataReaderProcessor);

            return sqlDataService;
        }

        private static IDataService CreateOleDbDataService(string connectionString)
        {
            //var importProcessor = new OleDbDataImportProcessor();
            var dataReaderProcessor = new OleDbDataReaderProcessor();
            var metadataProcessor = new OleDbMetadataProcessor();

            var oleDbDataService = new DataService(connectionString,
                metadataProcessor, null/*importProcessor*/, dataReaderProcessor);

            return oleDbDataService;
        }
    }

    
}
