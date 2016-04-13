using System;
using System.Collections.Generic;

using Escyug.Importer.Common;
using Escyug.Importer.Data;
using Escyug.Importer.Data.Sql;

namespace Escyug.Importer.Models
{
    public sealed class DataInstanceCreator
    {
        private static readonly Dictionary<Constants.FilesTypes, Func<string, IDataInstance>> _filesInstances =
            new Dictionary<Constants.FilesTypes, Func<string, IDataInstance>> 
            {
                { Constants.FilesTypes.Sql,  connectionString => new SqlDataInstance(connectionString) }
            };

        public static IDataInstance CreateInstance(Constants.FilesTypes fileType, string connectionString)
        {
            return _filesInstances[fileType](connectionString);
        }
    }
}
