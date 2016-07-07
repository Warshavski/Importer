using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Processors
{
    public interface IAsyncDeleteDataProcessor
    {
        Task DeleteDataAsync(IDataReader dataReader, string targetTableName);
        Task DeleteDataAsync(IDataReader dataReader, string targetTableName, string targetConnectionString);
    }
}
