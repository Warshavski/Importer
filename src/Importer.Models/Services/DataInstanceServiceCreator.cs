﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Common;
using Escyug.Importer.Models.Repository;

namespace Escyug.Importer.Models.Services
{
    public sealed class DataInstanceServiceCreator
    {
        public static DataInstanceService CreateService(Constants.FilesTypes fileType)
        {
            switch (fileType)
            {
                case Constants.FilesTypes.Sql :
                    return new DataInstanceService(new SqlDataInstanceRepository());
                case Constants.FilesTypes.OleDb :
                    return new DataInstanceService(new OleDbDataInstanceRepository());
                default :
                    return null;
            }
        }
    }
}