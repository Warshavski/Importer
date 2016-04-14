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
using Escyug.Importer.Models.Services;



namespace Escyug.Importer.UI.ConsoleApp
{
    sealed class Program
    {
        static void PrintEntities(IEnumerable entitiesEnum)
        {
            foreach (var entitie in entitiesEnum)
                Console.WriteLine(entitie.ToString());
        }

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.Write("Reading connection strings...");

            var connectionStrings = new List<string>();
            var connectionStringsFilePath = @"C:\test\connectionStrings.txt";
            using (var reader = new StreamReader(connectionStringsFilePath, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                    connectionStrings.Add(reader.ReadLine());
            }

            Console.WriteLine("done." + Environment.NewLine);

            var sqlService = DataInstanceServiceCreator.CreateService(Constants.FilesTypes.Sql);

            var sqlInstance = sqlService.CreateInstance(connectionStrings[0]);

            PrintEntities(sqlInstance.Tables);

            watch.Stop();
            
            var elapsed = watch.ElapsedMilliseconds;
            
            Console.WriteLine(Environment.NewLine + "Complete. Time elapsed : " + elapsed + " ms.");
        }
    }
}