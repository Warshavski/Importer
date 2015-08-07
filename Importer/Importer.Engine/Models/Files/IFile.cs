using System.Collections.Generic;

namespace Importer.Engine.Models
{
    /* TODO :
     *   1. ??? Change interface on abstract class. ??? */
    public interface IFile
    {
        // connection string for each file
        string ConnectionString { get; }

        // list of tables in each file
        List<Table> TableList { get; }

        /// <summary>
        /// testing connection 
        /// same function realization in all classes (must be common)
        /// </summary>
        /// <returns>
        /// true - if connection succeeded
        /// false - if connection failed
        /// </returns>
        bool TestConnection();

        /// <summary>
        /// initialize tables
        /// ??abstact class??
        /// same function realization in all classes (must be common)
        /// </summary>
        /// <param name="isSource">if is source file</param>
        void InitializeTables(bool isSource);
        //void ImportData(Table sourceTable, Table targetTable);
    }
}
