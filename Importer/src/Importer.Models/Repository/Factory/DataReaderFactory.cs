using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql;
using Escyug.Importer.Data.OleDb;

namespace Escyug.Importer.Models.Repository.Factory
{
    public class DataReaderFactory
    {
        public static IDataReaderProcessor Create(string fileType)
        {
            IDataReaderProcessor readerProcessor;
            switch (fileType)
            {
                case Constants.FileType.SQL :
                    readerProcessor = new SqlDataReaderProcessor();
                    break;
                case Constants.FileType.OLEDB:
                    readerProcessor = new OleDbDataReaderProcessor();
                    break;
                default :
                    readerProcessor = null;
                    break;
            }

            return readerProcessor;
        }
    }
}
