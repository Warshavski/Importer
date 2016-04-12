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

            Console.Write("Initializing instances...");

            var connectionStrings = new List<string>();
            
            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            using (var reader = new StreamReader(connectionStringsFilePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                    connectionStrings.Add(reader.ReadLine());
            }

            var oleDbDataService = new OleDbDataService();
            var excelDataInstance = oleDbDataService.CreateInstance(connectionStrings[5]);

            var sqlImportService = new SqlDataImportService(
                Constants.FileType.OLEDB, 
                (rowsCopied) => { Console.WriteLine("    # Rows copied : " + rowsCopied); });

            var sqlDataService = new SqlDataService();
            var sqlDataInstanceSource = sqlDataService.CreateInstance(connectionStrings[0]);
            var sqlDataInstanceTarget = sqlDataService.CreateInstance(connectionStrings[3]);

            Console.WriteLine("\tdone.");

            Console.Write("Setup source instance...");

            foreach (var table in excelDataInstance.Tables)
            { 
                if (table.Name == "wat$")
                {
                    table.MarkForImport();
                    break;
                }
            }

            var mappingsFilePath = @"C:\test\mappings_jv.txt";

            var columnsMappings = new List<ColumnsMapping>();
            using (var columnsMappingReader = new StreamReader(mappingsFilePath, Encoding.UTF8))
            {
                while(!columnsMappingReader.EndOfStream)
                {
                    var mappingsString = columnsMappingReader.ReadLine();
                    
                    var mappings = mappingsString.Split('-');

                    columnsMappings.Add(new ColumnsMapping(mappings[0], mappings[1]));
                }
                    
            }
            

            Console.WriteLine("\tdone.");

            Console.Write("Setup target instance...");
            foreach (var table in sqlDataInstanceTarget.Tables)
            {
                if (table.Name == "VITAL")
                {
                    table.MarkForImport();
                    break;
                }
            }

            Console.WriteLine("\tdone.");

            Console.WriteLine("Import in progress...");
            Console.WriteLine("....");

            sqlImportService.Import(excelDataInstance, sqlDataInstanceTarget, columnsMappings);
            
            watch.Stop();
            
            var elapsed = watch.ElapsedMilliseconds;
            
            Console.WriteLine(Environment.NewLine + "Complete. Time elapsed : " + elapsed + " ms.");
        }
    }
}