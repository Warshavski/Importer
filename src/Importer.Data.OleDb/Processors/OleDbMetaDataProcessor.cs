using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

using Escyug.Importer.Data.Common;
using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;

namespace Escyug.Importer.Data.OleDb.Processors
{
    // same class implementation in SqlMetadataProcessor (different connections)
    public class OleDbMetadataProcessor : IMetadataProcessor
    {
        private const string PROVIDER_NAME = "System.Data.OleDb";

        /* Names of OleDb data types
        private static Dictionary<int, string> _dataTypes = new Dictionary<int, string>()
        {
            { 20, "DBTYPE_I8"},
            {128, "DBTYPE_BYTES"},
            {11, "DBTYPE_BOOL"},
            {8, "DBTYPE_BSTR"},
            {136, "DBTYPE_HCHAPTER"},
            {129, "DBTYPE_STR"},
            {6, "DBTYPE_CY"},
            {7, "DBTYPE_DATE"},
            {133, "DBTYPE_DBDATE"},
            {134, "DBTYPE_DBTIME"},
            {135, "DBTYPE_DBTIMESTAMP"},
            {14, "DBTYPE_DECIMAL"},
            {5, "DBTYPE_R8"},
            {0, "DBTYPE_EMPTY"},
            {10, "DBTYPE_ERROR"},
            {64, "DBTYPE_FILETIME"},
            {72, "DBTYPE_GUID"},
            {9, "DBTYPE_IDISPATCH"},
            {3, "DBTYPE_I4"},
            {13, "DBTYPE_IUNKNOWN"},
            {131, "DBTYPE_NUMERIC"},
            {138, "DBTYPE_PROP_VARIANT"},
            {4, "DBTYPE_R4"},
            {2, "DBTYPE_I2"},
            {16, "DBTYPE_I1"},
            {21, "DBTYPE_UI8"},
            {19, "DBTYPE_UI4"},
            {18, "DBTYPE_UI2"},
            {17, "DBTYPE_UI1"},
            {132, "DBTYPE_UDT"},
            {12, "DBTYPE_VARIANT"},
            {130, "DBTYPE_WSTR"}
        };
        */

        public OleDbMetadataProcessor()
        {
          
        }

        #region IMetadataProcessor members

        public IEnumerable<Table> GetTablesMetadata(string connectionString)
        {
            return DbCommonHelper.GetTablesMetadata(connectionString, PROVIDER_NAME);
        }

        public IEnumerable<Column> GetColumnsMetadata(string connectionString, string tableName)
        {
            using (var connection = new OleDbConnection(connectionString))
            {
                return DbCommonHelper.GetColumnsMetadata(connection, tableName);
            }
        }

        public bool TestConnection(string connectionString)
        {
            return DbCommonHelper.TestConnection(PROVIDER_NAME, connectionString);
        }

        #endregion IMetadataProcessor members
    }
}
