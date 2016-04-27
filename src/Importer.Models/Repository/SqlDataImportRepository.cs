using System;
using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Models.Repository
{
    public class SqlDataImportRepository : IDataImportRepository
    {
        private readonly IDataImportProcessor _importProcessor;
        private readonly IDataReaderProcessor _dataReaderProcessor;

        // ?? DI ?? yeah DI, bitch! but something wrong with this shit...
        public SqlDataImportRepository(IDataImportProcessor importProcessor, 
            IDataReaderProcessor dataReaderProcessor)
        {
            _importProcessor = importProcessor;
            _dataReaderProcessor = dataReaderProcessor;
        }

        // ?? DI ?? yeah DI, bitch! but something wrong with this shit...
        public SqlDataImportRepository(IDataImportProcessor importProcessor,
            IDataReaderProcessor dataReaderProcessor, Action<long> importNotify)
        {
            _importProcessor = importProcessor;
            _dataReaderProcessor = dataReaderProcessor;
            _importProcessor.RowsCopiedNotify += importNotify;
        }

        public void Import(string sourceConnectionString, string sourceTableName, 
            string targetConnectionString, string targetTableName)
        {
            using (var dataReader = _dataReaderProcessor.CreateReader(sourceTableName, sourceConnectionString))
                _importProcessor.Import(dataReader, targetConnectionString, targetTableName);
        }

        public void Import(string sourceConnectionString, string sourceTableName,
          string targetConnectionString, string targetTableName, IEnumerable<ColumnsMapping> columnsMappings)
        {
            using (var dataReader = _dataReaderProcessor.CreateReader(sourceTableName, sourceConnectionString))
                _importProcessor.Import(dataReader, targetConnectionString, targetTableName, columnsMappings);
        }

        
    }
}
