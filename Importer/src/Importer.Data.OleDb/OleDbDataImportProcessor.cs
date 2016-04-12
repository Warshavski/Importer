using System;

using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb
{
    public class OleDbDataImportProcessor : IDataImportProcessor
    {
        public void Import(System.Data.IDataReader sourceDataReader, string targetConnectionString, string targetTableName)
        {
            throw new NotImplementedException();
        }
    }
}
