using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public sealed class DataInstanceService : IDataInstanceService
    {
        private readonly IDataInstanceRepository _dataInstanceRepository;

        internal DataInstanceService(IDataInstanceRepository dataInstanceRepository)
        {
            _dataInstanceRepository = dataInstanceRepository;
        }

        public DataInstance CreateInstance(string connectionString)
        {
            var metadata = _dataInstanceRepository.GetMetadata(connectionString);

            return new DataInstance(connectionString, metadata);
        }
    }
}
