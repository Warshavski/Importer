using Escyug.Importer.Common;
using Escyug.Importer.Data.Sql.Processors;
using Escyug.Importer.Data.OleDb.Processors;

namespace Escyug.Importer.Models.Repository
{
    public class ImportRepositoryCreator
    {
        // yeah creates only SqlDataImporter
        public static IDataImportRepository Create(Constants.DataInstanceTypes fileType)
        {
            switch (fileType)
            {
                case Constants.DataInstanceTypes.Sql :
                    return new SqlDataImportRepository(
                        new SqlDataImportProcessor(), new SqlDataReaderProcessor());
                case Constants.DataInstanceTypes.OleDb :
                    return new SqlDataImportRepository(
                        new SqlDataImportProcessor(), new OleDbDataReaderProcessor());
                default :
                    return null;
            }
        }
    }
}
