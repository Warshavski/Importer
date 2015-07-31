using System.Collections.Generic;

namespace Importer.Engine.Models
{
    public interface IFile
    {
        // connection string for each file
        string ConnectionString { get; }

        // list of tables in each file
        IList<Table> TableList { get; }

        /// <summary>
        /// testing connection
        /// </summary>
        /// <returns>
        /// true - if connection succeeded
        /// false - if connection failed
        /// </returns>
        bool TestConnection();

        /// <summary>
        /// initialize tables
        /// </summary>
        /// <param name="isSource">if is source file</param>
        void InitializeTables(bool isSource);
        //void ImportData(Table sourceTable, Table targetTable);
    }
}
