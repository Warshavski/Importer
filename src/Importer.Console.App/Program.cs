using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data.Metadata;
using Escyug.Importer.Data.Processors;
using Escyug.Importer.Data.OleDb.Processors;
using Escyug.Importer.Data.Sql.Processors;

using Escyug.Importer.Models.Services;


namespace Importer.Console.App
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Reading connection strings..." + Environment.NewLine);

            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            var connectionStrings = ReadConnectionStrings(connectionStringsFilePath);

            var sqlDataService = DataServiceFactory.Create(DataServicesTypes.Sql, connectionStrings[1]);
            var metadata = sqlDataService.GetMetaData();
            PrintMetaData(metadata);

            using (var reader = sqlDataService.GetDataReader("test3"))
            {
                sqlDataService.ImportData(reader, "test1");
            }

            System.Console.WriteLine("wat wat");
        }

        private static List<string> ReadConnectionStrings(string path)
        {
            var connectionStrings = new List<string>();
            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                    connectionStrings.Add(reader.ReadLine());
            }

            return connectionStrings;
        }

        private static void PrintMetaData(IEnumerable<Table> metadata)
        {
            foreach (var table in metadata)
            {
                System.Console.WriteLine(table.Name);
            }
        }
    }
}
