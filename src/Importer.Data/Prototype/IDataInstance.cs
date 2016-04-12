using System.Data;

namespace Escyug.Importer.Data.Prototype
{
    public interface IDataInstance
    {
        string ConnectionString { get; set; }

        bool TestConnection();

        DataTable GetTableSchemas();
        DataTable GetColumnSchemas(string tableName);
        DataTable GetData(string tableName);
    }
}
