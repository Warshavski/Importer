using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public sealed class DataInstanceService
    {
        private readonly IDataInstanceRepository _dataInstanceRepository;

        internal DataInstanceService(IDataInstanceRepository dataInstanceRepository)
        {
            _dataInstanceRepository = dataInstanceRepository;
        }

        public DataInstance CreateInstance(string connectionString)
        {
            var metaData = _dataInstanceRepository.GetMetaData(connectionString);

            return new DataInstance(connectionString, metaData);
        }

    }
}
