using System.Collections.Generic;

using Escyug.Importer.Data.Metadata;

namespace Escyug.Importer.Data.Processors
{
    public interface IMetadataProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        IEnumerable<Table> GetTablesMetadata(string connectionString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        IEnumerable<Column> GetColumnsMetadata(string connectionString, string tableName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        bool TestConnection(string connectionString);
    }
}
