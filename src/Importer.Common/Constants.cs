namespace Escyug.Importer.Common
{
    public static class Constants
    {
        public static class ProviderName
        {
            public const string SQL_PROVIDER = "System.Data.SqlClient";
            public const string OLEDB_PROVIDER = "System.Data.OleDb";
        }

        // replace by enum
        public static class FileType
        {
            public const string OLEDB = "oledb";
            public const string SQL = "sql";
            public const string XML = "xml";
        }

        // replace by enum
        public enum FilesTypes
        {
            OleDb,
            Sql,
            Xml
        }
    }
}
