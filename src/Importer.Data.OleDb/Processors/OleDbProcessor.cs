using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escyug.Importer.Data.OleDb.Processors
{
    public class OleDbProcessor
    {
        protected const string PROVIDER_NAME = "System.Data.OleDb";

        protected virtual string CreateSelectCommandText(params string[] parameters)
        {
            string commandText = "SELECT * FROM [" + parameters[0] + "]";
            return commandText;
        }
    }
}
