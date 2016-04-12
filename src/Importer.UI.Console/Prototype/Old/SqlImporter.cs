using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Escyug.Importer.UI.ConsoleApp.Prototype.Old
{
    public class SqlImporter : IImporter
    {
        #region Properties

        private string _targetConnectionString;
        public string TargetConnectionString
        {
            get { return _targetConnectionString; }
            set { _targetConnectionString = value; }
        }

        private string _targetTable;
        public string TargetTableName
        {
            get { return _targetTable; }
            set { _targetTable = value; }
        }

        private IEnumerable<Mapping> _mappings;
        public IEnumerable<Mapping> Mappings
        {
            get { return _mappings; }
            set { _mappings = value; }
        }

        #endregion

        // ?? how to throw SqlRowsCopied event ??
        public event Action<string> StatusUpdated;
        public event Action<string> ImportStatusChanged;

        private IDataReader _sourceReader;

        #region Constructors

        public SqlImporter(IDataReader sourceReader)
        {
            _sourceReader = sourceReader;
        }

        public SqlImporter(string targetConnectionString, string targetTableName, 
            IDataReader sourceReader, IEnumerable<Mapping> mappings) 
        {
            _targetConnectionString = targetConnectionString;
            _targetTable = targetTableName;

            _mappings = mappings;
            _sourceReader = sourceReader;
        }

        #endregion 

        #region Helper methods

        private void Invoke(Action<string> action, string message)
        {
            if (action != null)
                action.Invoke(message);
        }

        // clear all data from table
        private void TruncateTable(string tableName, string connectionString)
        {
            var commandText = string.Format("TRUNCATE TABLE dbo.[{0}]", tableName);

            using (var connection = DbAccessHelper.CreateDbConnection(
                Constants.ProviderName.SQL_PROVIDER, connectionString))
            {
                connection.Open();
                try
                {
                    var command = DbAccessHelper.CreateCommand(commandText, connection);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion

        public void Import(IDataInstance source, IDataInstance target, bool truncateTarget)
        {
            throw new NotImplementedException();
        }

        public void Import(bool isTruncate)
        {
            if (_targetConnectionString == string.Empty)
                throw new ArgumentException("Connection string should be set");

            // should use target connection string 
            using (var bulkCopy = new SqlBulkCopy(_targetConnectionString))
            {
                bulkCopy.DestinationTableName = _targetTable;

                Invoke(StatusUpdated, "creating mappings...");

                // create mappings for SqlBulkCopy instance
                foreach (var map in _mappings)
                    bulkCopy.ColumnMappings.Add(map.SourceColumnName, map.TargetTableName);
                
                // dynamic count
                bulkCopy.BatchSize = 5000;
                bulkCopy.BulkCopyTimeout = 60;
                bulkCopy.NotifyAfter = 5000;

                try
                {
                    if (isTruncate)
                    {
                        Invoke(StatusUpdated, "truncate table...");        
                        
                        TruncateTable(_targetTable, _targetConnectionString);
                    }

                    bulkCopy.SqlRowsCopied += (sender, e) => 
                        Invoke(StatusUpdated, string.Format("rows copied : {0}", e.RowsCopied));

                    bulkCopy.WriteToServer(_sourceReader);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }
    }
}


/* old test versions */
/*
      public void CreateImportData(DataTable source, DataTable target)
      {
          var result = source.AsEnumerable()
              .Select(r => r.Field<long>("id"))
              .Except(target.AsEnumerable()
                  .Select(r => r.Field<long>("id")));
      }

      public void Import(int minID)
      {
          string selectCommand = @"SELECT * FROM dbo.[doc] WHERE Id > @id ORDER BY ID";

          SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, _connection);
          adapter.SelectCommand.Parameters["@id"].Value = minID;

          DataSet data = new DataSet();
          adapter.Fill(data);

      }

      public void Import(string targetColumnName, IEnumerable<Mapping> mappings)
      {
          if (_data == null)
              throw new NullReferenceException("Data collection is empty");

          _bulkCopy = new SqlBulkCopy(_connection);

          _bulkCopy.DestinationTableName = targetColumnName;

          foreach (var element in mappings)
              _bulkCopy.ColumnMappings.Add(element.SourceColumn, element.TargetColumn);

          _bulkCopy.WriteToServer(_data);
      }
      */