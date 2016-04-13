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

using Escyug.Importer.Common;
using Escyug.Importer.Models;

namespace Escyug.Importer.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            var connectionStrigns = new List<string>();
            using (var reader = new StreamReader(connectionStringsFilePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                    connectionStrigns.Add(reader.ReadLine());
            }

            /* Reads mappings
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
            */

            var sqlDataInstance = DataInstanceCreator.CreateInstance(Constants.FilesTypes.Sql, connectionStrigns[0]);

            Console.Write("Connection test...");
            Console.WriteLine(sqlDataInstance.TestConnection());

            watch.Stop();
            
            var elapsed = watch.ElapsedMilliseconds;
            
            Console.WriteLine(Environment.NewLine + "Complete. Time elapsed : " + elapsed + " ms.");
        }
    }
}