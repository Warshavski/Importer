﻿using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Importer.Engine.Models
{
    internal class SqlFile : IFile
    {
        private const string PROVIDER_NAME = "System.Data.SqlClient";

        /// <summary>
        /// main SqlFile constructor
        /// </summary>
        /// <param name="filePath">Data source and catalog name (Data Source={source string}; Initial Catalog={catalog name};)</param>
        /// <param name="property">Extended property (windows or server security)</param>
        internal SqlFile(string filePath, PropertyInfo property)
        {
            // initialize connection string
            _connectionString = string.Format(
                "{0} {1}", filePath, property.Value);
            // initialize table list by null value
            _tableList = null;
        }

        // 
        internal SqlFile(string connectionString)
        {
            _connectionString = connectionString;
            _tableList = null;
        }

        #region Члены IFile

        // create connection string property
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        // create table list property
        private IList<Table> _tableList = null;
        public IList<Table> TableList
        {
            get { return _tableList; }
        }

        /// <summary>
        /// test connection string
        /// </summary>
        /// <returns>valid/not valid connection (bool)</returns>
        public bool TestConnection()
        {
            try
            {
                // trying to create connection
                using (var connection = CommonData.CreateDbConnection(PROVIDER_NAME, _connectionString))
                {
                    // trying to open connection
                    connection.Open();
                    // trying to close connection
                    connection.Close();
                    // return connection is valid
                    return true;
                }
            }
            // catch DbException
            catch (DbException)
            {
                // return connection is not valid
                return false;
            }
        }

        /// <summary>
        /// static method for testing connection
        /// </summary>
        /// <param name="connectionString">testing connection string</param>
        /// <returns>valid/not valid connection (bool)</returns>
        public static bool TestConnection(string connectionString)
        {
            try
            {
                using (var connection = CommonData.CreateDbConnection(PROVIDER_NAME, connectionString))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (DbException)
            {
                return false;
            }
        }

        /// <summary>
        /// initialize tables
        /// </summary>
        public void InitializeTables(bool isSource)
        {
            // create Sql connection
            using (DbConnection connection = CommonData.CreateDbConnection(PROVIDER_NAME, _connectionString))
            {
                // initialize link to empty List<SourceTable>
                _tableList = new List<Table>();

                //open connection
                connection.Open();
                //create and get information about tables from connection schema 
                DataTable dtTables = connection.GetSchema("Tables");
               
                // foreach element in 
                foreach (DataRow dtTablesRow in dtTables.Rows)
                    _tableList.Add(new Table((string)dtTablesRow["TABLE_NAME"], connection, PROVIDER_NAME, isSource));

                // close connection
                connection.Close();

                // dispose DataTable that contains information about tables
                dtTables.Dispose();
                dtTables = null;
            }
        }

        #endregion
    }
}
