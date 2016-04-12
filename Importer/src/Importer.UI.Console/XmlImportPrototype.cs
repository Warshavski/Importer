using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Schema;

namespace Escyug.Importer.UI.ConsoleApp
{
    internal class XmlImportPrototype
    {
        public event Action RowAdded;

        private string _connectionString;
        private string _filePath;

        private DataSet _schema;

        public XmlImportPrototype(string connectionString, string filePath)
        {
            _connectionString = connectionString;
            _filePath = filePath;

            GetSchema();
        }

        private void Invoke(Action action)
        {
            if (action != null)
                action.Invoke();
        }

        private void GetSchema()
        {
            _schema = new DataSet();
            using (var reader = XmlReader.Create(_filePath))
                _schema.ReadXmlSchema(reader);
        }

        public DataSet GetData()
        {
            DataSet xmlDataSet = new DataSet();

            xmlDataSet.ReadXml(_filePath);

            return xmlDataSet;
        }

        public DataSet GetData(string tableName)
        {
            var data = new DataSet();

            return data;
        }

        public IList<string> GetTablesNames()
        {
            var tablesList = new List<string>();

            foreach (DataTable table in _schema.Tables)
                tablesList.Add(table.TableName);

            return tablesList;
        }

        public IList<string> GetColumnsNames(string tableName)
        {
            var columnsList = new List<string>();

            foreach (DataColumn column in _schema.Tables[tableName].Columns)
                columnsList.Add(column.ColumnName);

            return columnsList;
        }

        public async void WriteToFile(string outputFile, DataSet data) 
        {
            using (StreamWriter writer = File.CreateText(outputFile))
            {
                foreach (DataTable table in data.Tables)
                {
                    await writer.WriteLineAsync(table.TableName);

                    StringBuilder columnsHeader = new StringBuilder();

                    foreach (DataColumn column in table.Columns)
                    {
                        columnsHeader.AppendFormat("| {0} |", column.ColumnName);
                        Invoke(RowAdded);
                    }
                        
                    await writer.WriteLineAsync(columnsHeader.ToString());
                    await writer.WriteLineAsync(Environment.NewLine);

                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn col in table.Columns)
                        {
                            Console.WriteLine(row[col]);
                        }
                    }
                }
            } 
        }
    }
}