using System;
using System.Collections.Generic;

using Escyug.Importer.Data.MetaData;

namespace Escyug.Importer.Data
{
    public interface IDataInstance
    {
        IEnumerable<Table> Tables { get; }
        string ConnectionString { get; }

        bool TestConnection();
        void Initialize();
        //void Import(Action<long> RowsCopied);
    }
}
