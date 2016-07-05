using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;
using System.Data;

namespace Escyug.Importer.Models.Repository
{
    public interface IDataRepository
    {
        IEnumerable<Table> GetMetaData();

        void ImportData(IDataReader dataReader, string destinationTable);
    }
}
