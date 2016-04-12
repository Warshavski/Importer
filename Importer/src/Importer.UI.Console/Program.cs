using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Xml.Linq;

/*
using Escyug.Importer.UI.ConsoleApp.Prototype;
using Escyug.Importer.UI.ConsoleApp.Beta;
using Escyug.Importer.UI.ConsoleApp.Prototype.Old;
*/

using Escyug.Importer.Common;
using Escyug.Importer.Models;
using Escyug.Importer.Models.Services;


namespace Escyug.Importer.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine("Initializing instances...");

            var connectionStrings = new List<string>();
            
            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            using (var reader = new StreamReader(connectionStringsFilePath))
            {
                while (!reader.EndOfStream)
                    connectionStrings.Add(reader.ReadLine());
            }

            var oleDbDataService = new OleDbDataService();
            var excelDataInstance = oleDbDataService.CreateInstance(connectionStrings[5]);

            var sqlImportService = new SqlDataImportService(Constants.FileType.SQL);

            var sqlDataService = new SqlDataService();
            var sqlDataInstanceSource = sqlDataService.CreateInstance(connectionStrings[0]);
            var sqlDataInstanceTarget = sqlDataService.CreateInstance(connectionStrings[4]);

            Console.WriteLine("Setup source instance...");

            foreach (var table in sqlDataInstanceSource.Tables)
            { 
                if (table.Name == "test1")
                {
                    table.MarkForImport();
                    break;
                }
            }

            Console.WriteLine("Setup target instance...");
            foreach (var table in sqlDataInstanceTarget.Tables)
            {
                if (table.Name == "testImport")
                {
                    table.MarkForImport();
                    break;
                }
            }

            Console.WriteLine("Import in progress...");

            sqlImportService.Import(sqlDataInstanceSource, sqlDataInstanceTarget);

            watch.Stop();
            
            var elapsed = watch.ElapsedMilliseconds;
            
            Console.WriteLine(Environment.NewLine + "Complete. Time elapsed : " + elapsed + " ms.");
        }
    }
}