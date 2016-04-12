using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public class OleDbDataService
    {
        private readonly OleDbDataRepository _oleDbRepository;

        public OleDbDataService()
        {
            _oleDbRepository = new OleDbDataRepository();
        }

        public IDataInstance CreateInstance(string connectionString)
        {
            var tablesMetaDataList = _oleDbRepository.SelectTables(connectionString);

            return new DataInstance(connectionString, tablesMetaDataList);
        }
    }
}
