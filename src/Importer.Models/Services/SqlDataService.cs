using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public class SqlDataService
    {
        private readonly SqlDataRepository _sqlRepository;

        public SqlDataService()
        {
            _sqlRepository = new SqlDataRepository();
        }

        public IDataInstance CreateInstance(string connectionString)
        {
            var tablesMetaDataList = _sqlRepository.SelectTables(connectionString);

            return new DataInstance(connectionString, tablesMetaDataList);
        }
    }
}
