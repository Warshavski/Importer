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

        //private static Dictionary<DataServicesTypes, Func<string, IAsyncDataService>> _asyncDataServicesCreators =
        //    new Dictionary<DataServicesTypes, Func<string, IAsyncDataService>>()
        //    {
        //        { DataServicesTypes.OleDb, CreateAsyncOleDbDataService },
        //        { DataServicesTypes.Sql, CreateAsyncSqlDataService }
        //    };

        private static List<Func<string, IAsyncDataService>> _asyncDataServicesCreators =
            new List<Func<string, IAsyncDataService>>() 
            {
                CreateAsyncOleDbDataService,
                CreateAsyncSqlDataService
            };

        public static IDataService Create(DataServicesTypes serviceType, string connectionString)
        {
            return _dataServicesCreators[serviceType].Invoke(connectionString);
        }

        public static IAsyncDataService CreateAsync(DataServicesTypes serviceType, string connectionString)
        {
            switch (serviceType)
            {
                case DataServicesTypes.OleDb :
                    return _asyncDataServicesCreators[0].Invoke(connectionString);
                case DataServicesTypes.Sql :
                    return _asyncDataServicesCreators[1].Invoke(connectionString);
                default :
                    return null;
            }
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

        private static IAsyncDataService CreateAsyncSqlDataService(string connectionString)
        {
            var importProcessor = new AsyncSqlDataImportProcessor();
            var dataReaderProcessor = new AsyncSqlDataReaderProcessor();
            var metadataProcessor = new SqlMetadataProcessor();
            var queryProcessor = new AsyncSqlTruncateTableProcessor();
            var deleteDataProcessor = new AsyncSqlDeleteDataProcessor();

            var sqlDataService = new AsyncDataService(connectionString,
                metadataProcessor, importProcessor, dataReaderProcessor, 
                queryProcessor, deleteDataProcessor);

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

        private static IAsyncDataService CreateAsyncOleDbDataService(string connectionString)
        {
            //var importProcessor = new OleDbDataImportProcessor();
            var dataReaderProcessor = new AsyncOleDbDataReaderProcessor();
            var metadataProcessor = new OleDbMetadataProcessor();

            var oleDbDataService = new AsyncDataService(connectionString,
                metadataProcessor, null/*importProcessor*/, dataReaderProcessor, null, null);

            return oleDbDataService;
        }
    }

    
}
