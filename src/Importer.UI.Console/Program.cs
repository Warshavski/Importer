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

namespace Escyug.Importer.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.Write("Initializing instances...");

            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            var connectionStrings = new List<string>();
            using (var reader = new StreamReader(connectionStringsFilePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                    connectionStrings.Add(reader.ReadLine());
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
            
            watch.Stop();
            
            var elapsed = watch.ElapsedMilliseconds;
            
            Console.WriteLine(Environment.NewLine + "Complete. Time elapsed : " + elapsed + " ms.");
        }
    }
}