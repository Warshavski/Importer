using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Models;

namespace Escyug.Importer.Models.Repository
{
    internal interface IDataInstanceRepository
    {
        IEnumerable<Table> GetMetaData(string connectionString);
        bool TestConnection(string connectionString);
        // get data
    }
}
