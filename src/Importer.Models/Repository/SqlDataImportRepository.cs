using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.Sql.Processors;

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

        public void Import()
        {
            throw new NotImplementedException();
        }

        public void Import(string sourceConnectionString, string sourceTableName, 
            string targetConnectionString, string targetTableName)
        {
            using (var dataReader = _dataReaderProcessor.CreateReader(sourceTableName, sourceConnectionString))
                _importProcessor.Import(dataReader, targetConnectionString, targetTableName);
        }
    }
}
