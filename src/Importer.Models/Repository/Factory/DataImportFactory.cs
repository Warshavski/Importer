using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql;
using Escyug.Importer.Data.OleDb;

namespace Escyug.Importer.Models.Repository.Factory
{
    public class DataImportFactory
    {
        public static IDataImportProcessor Create(string fileType)
        {
            IDataImportProcessor importProcessor;

            switch (fileType)
            {
                case Constants.FileType.SQL :
                    importProcessor = new SqlDataImportProcessor();
                    break;
                case Constants.FileType.OLEDB:
                    importProcessor = new OleDbDataImportProcessor();
                    break;
                default :
                    importProcessor= null;
                    break;
            }

            return importProcessor;
        }
    }
}
