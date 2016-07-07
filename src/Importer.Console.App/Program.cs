using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Data;
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

            var sqlDataService = DataServiceFactory.CreateAsync(DataServicesTypes.Sql, connectionStrings[3]);
            var excelDataService = DataServiceFactory.CreateAsync(DataServicesTypes.OleDb, connectionStrings[5]);
            
            var columnsMappings = new List<ColumnsMapping>()
            {
                new ColumnsMapping("NPP", "NPP"),
                new ColumnsMapping("MNN", "MNN"),
                new ColumnsMapping("TRADENAME", "TRADENAME"),
                new ColumnsMapping("DRUGFORM", "DRUGFORM"),
                new ColumnsMapping("FIRM", "FIRM"),
                new ColumnsMapping("QNT", "QNT"),
                new ColumnsMapping("PRICE", "PRICE"),
                new ColumnsMapping("MAXPRICE", "MAXPRICE"),
                new ColumnsMapping("EAN13", "EAN13")
            };

            Stopwatch sw = new Stopwatch();

            sw.Start();

            Task.WaitAll(Import(excelDataService, sqlDataService, columnsMappings));
          
            sw.Stop();

            System.Console.WriteLine("Elapsed={0}", sw.Elapsed);

        }

        private async static Task Import(IAsyncDataService source, IAsyncDataService destination,
            IEnumerable<ColumnsMapping> mappings)
        {
            using (var dataReader = await source.GetDataReader("wat$"))
            {
                await destination.ImportData(dataReader, "VITAL", mappings);
            }
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
