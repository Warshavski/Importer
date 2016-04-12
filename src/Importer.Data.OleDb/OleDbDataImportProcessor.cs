using System;
using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb
{
    public class OleDbDataImportProcessor : IDataImportProcessor
    {
        public event Action<long> RowsCopiedNotify;

        public void Import(System.Data.IDataReader sourceDataReader, string targetConnectionString, string targetTableName)
        {
            throw new NotImplementedException();
        }

        public void Import(System.Data.IDataReader sourceDataReader, string targetConnectionString, string targetTableName, 
            IEnumerable<ColumnsMapping> columnsMappings)
        {
            throw new NotImplementedException();
        }
    }
}
