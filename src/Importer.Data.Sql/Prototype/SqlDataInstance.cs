using System;
using System.Data;

using Escyug.Importer.Common;
using Escyug.Importer.Data.Prototype;

namespace Escyug.Importer.Data.Sql.Prototype
{
    public sealed class SqlDataInstance : IDataInstance
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public SqlDataInstance(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            return CommonDbHelper.TestConnection(
                Constants.ProviderName.SQL_PROVIDER, _connectionString);
        }

        public System.Data.DataTable GetTableSchemas()
        {
            var tableSchemasData = new DataTable();
            using (var connection = CommonDbHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, _connectionString))
            {
                try
                {
                    connection.Open();
                    tableSchemasData = connection.GetSchema("Tables");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw ex;
                }
            }

            return tableSchemasData;
        }

        public System.Data.DataTable GetColumnSchemas(string tableName)
        {
            var columnSchemasData = new DataTable();
            var restrictions = new string[4];
            using (var connection = CommonDbHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, _connectionString))
            {
                try
                {
                    connection.Open();

                    restrictions[2] = tableName;
                    columnSchemasData = connection.GetSchema("Columns", restrictions);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw ex;
                }
            }

            return columnSchemasData;
        }

        public System.Data.DataTable GetData(string tableName)
        {
            //var tableData = new DataTable(tableName);
            //using(var connection = CommonDbHelper.CreateDbConnection(
            //    Constants.ProviderName.SQL_PROVIDER, _connectionString))
            //{
            //    var selectCommand = string.Format("SELECT * FROM dbo.[{0}]", tableName);
            //    try
            //    {
            //        connection.Open();
            //    }
            //    catch (System.Data.SqlClient.SqlException ex)
            //    {
            //        throw ex;
            //    }
            //}

            //return tableData;

            throw new NotImplementedException();
        }
    }
}
