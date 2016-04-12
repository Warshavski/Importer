using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Escyug.Importer.Data.Xml.Prototype
{
    public class Demo
    {
        private string _connectionString;
        private string _filePath;

        public Demo(string connectionString, string filePath)
        {
            _connectionString = connectionString;
            _filePath = filePath;
        }

        public void RunDemo()
        {
            using (XmlTextReader xmlTextReader = new XmlTextReader(_filePath))
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(_connectionString, SqlBulkCopyOptions.TableLock))
            {
                SetupBulkCopy(sqlBulkCopy);

                var reader = new LabResultDataReader(xmlTextReader);
                sqlBulkCopy.WriteToServer(reader);
            }
        }

        private static void SetupBulkCopy(SqlBulkCopy sqlBulkCopy)
        {
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(0, "TypeId"));
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, "OriginId"));
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, "ResultName"));
            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(3, "Description"));

            sqlBulkCopy.DestinationTableName = "LabResult";
        }
    }
}
