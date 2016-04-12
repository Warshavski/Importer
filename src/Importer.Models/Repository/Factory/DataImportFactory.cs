using System;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql;
using Escyug.Importer.Data.OleDb;

namespace Escyug.Importer.Models.Repository.Factory
{
    public class DataImportFactory
    {
        private static IDataImportProcessor CreateProcessor(string fileType)
        {
            IDataImportProcessor importProcessor;

            switch (fileType)
            {
                case Constants.FileType.SQL:
                    importProcessor = new SqlDataImportProcessor();
                    break;
                case Constants.FileType.OLEDB:
                    importProcessor = new OleDbDataImportProcessor();
                    break;
                default:
                    importProcessor = null;
                    break;
            }

            return importProcessor;
        }

        public static IDataImportProcessor Create(string fileType)
        {
            return CreateProcessor(fileType);
        }

        public static IDataImportProcessor Create(string fileType, Action<long> rowsCopiedNotify)
        {
            IDataImportProcessor importProcessor = CreateProcessor(fileType);

            importProcessor.RowsCopiedNotify += rowsCopiedNotify;

            return importProcessor;
        }

    }
}
