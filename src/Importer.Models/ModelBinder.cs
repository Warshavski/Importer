using System.Collections.Generic;

namespace Escyug.Importer.Models
{
    public class ModelBinder
    {
        public static IEnumerable<Models.Table> CreateModelTablesList(IEnumerable<Data.Entities.Table> dataTables)
        {
            var modelTablesList = new List<Models.Table>();
            foreach (var dataTablesItem in dataTables)
            {
                var modelTableName = dataTablesItem.Name;
                var modelColumnList = new List<Models.Column>();

                foreach (var dataColumnItem in dataTablesItem.Columns)
                {
                    var modelColumnName = dataColumnItem.Name;
                    var modelColumnType = dataColumnItem.Type;
                    var modelColmnLength = dataColumnItem.Length;

                    modelColumnList.Add(
                        new Models.Column(modelColumnName, modelColumnType, modelColmnLength));
                }

                modelTablesList.Add(new Models.Table(modelTableName, modelColumnList));
            }

            return modelTablesList;
        }
    }
}
