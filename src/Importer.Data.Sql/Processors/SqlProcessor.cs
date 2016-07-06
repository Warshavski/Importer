using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.Sql.Processors
{
    public class SqlProcessor
    {
        protected const string PROVIDER_NAME = "System.Data.SqlClient";

        protected virtual string CreateSelectCommandText(params string[] parameters)
        {
            string commandText = "SELECT * FROM dbo.[" + parameters[0] + "]";
            return commandText;
        }
    }
}
