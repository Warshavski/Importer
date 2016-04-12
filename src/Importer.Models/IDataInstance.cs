using System.Collections.Generic;

namespace Escyug.Importer.Models
{
    public interface IDataInstance
    {
        string ConnectionString { get; set; }

        IEnumerable<Table> Tables { get; }
    }
}
