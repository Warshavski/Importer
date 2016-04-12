using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Models.Repository
{
    public interface IRepository
    {
        IEnumerable<Table> GetTables();
        Table GetTable(string name);
        void Import();
    }
}
