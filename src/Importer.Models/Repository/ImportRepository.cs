using System;

using Escyug.Importer.Data.Processors;
using Escyug.Importer.Models.Repository.Factory;

namespace Escyug.Importer.Models.Repository
{
    public class ImportRepository
    {
        private readonly IDataImportProcessor _importProcessor;
        private readonly IDataReaderProcessor _readerProcessor;

        public ImportRepository(string sourceFileType, string targetFileType)
        {
            // create by factory method
            // importProcessor, readerProcessor
            _importProcessor = DataImportFactory.Create(targetFileType);
            _readerProcessor = DataReaderFactory.Create(sourceFileType);
        }

        public ImportRepository(string sourceFileType, string targetFileType, Action<long> rowsCopiedNotify)
        {
            // create by factory method
            // importProcessor, readerProcessor
            _importProcessor = DataImportFactory.Create(targetFileType, rowsCopiedNotify);
            _readerProcessor = DataReaderFactory.Create(sourceFileType);
        }

        public void Import(string sourceConnetionString, string sourceTableName,
            string targetConnectionString, string targetTableName)
        {
            using (var sourceDataReader = _readerProcessor.CreateReader(sourceTableName, sourceConnetionString))
            {
                _importProcessor.Import(sourceDataReader, targetConnectionString, targetTableName);
            }
        }
    }
}
