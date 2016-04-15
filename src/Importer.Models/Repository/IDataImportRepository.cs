namespace Escyug.Importer.Models.Repository
{
    public interface IDataImportRepository
    {
        void Import();
        void Import(string sourceConnectionString, string sourceTableName,
            string targetConnectionString, string targetTableName);
    }
}
