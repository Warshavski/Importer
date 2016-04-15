using Escyug.Importer.Common;
using Escyug.Importer.Data.Sql.Processors;
using Escyug.Importer.Data.OleDb.Processors;

namespace Escyug.Importer.Models.Repository
{
    public class ImportRepositoryCreator
    {
        // yeah creates only SqlDataImporter
        public static IDataImportRepository Create(Constants.FilesTypes fileType)
        {
            switch (fileType)
            {
                case Constants.FilesTypes.Sql :
                    return new SqlDataImportRepository(
                        new SqlDataImportProcessor(), new SqlDataReaderProcessor());
                case Constants.FilesTypes.OleDb :
                    return new SqlDataImportRepository(
                        new SqlDataImportProcessor(), new OleDbDataReaderProcessor());
                default :
                    return null;
            }
        }
    }
}
