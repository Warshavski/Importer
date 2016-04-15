using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Escyug.Importer.Data.Xml
{
    public class XmlDataReader : IDataReader
    {
        private readonly XmlReader _xmlReader;

        // define Metadata class
        private Dictionary<int, string> _fieldsMetadata;

        private object[] _currentLineValues;

        private string _tableName;

        public XmlDataReader(string filePath, string tableName)
        {
            _fieldsMetadata = GetFieldsMetadata(filePath, tableName);

            _tableName = "z:row"; // tableName;

            _xmlReader = XmlReader.Create(filePath);
            _xmlReader.MoveToContent();
        }

        private Dictionary<int, string> GetFieldsMetadata(string filePath, string tableName)
        {
            DataSet xmlSchema = new DataSet();
            xmlSchema.ReadXmlSchema(filePath);

            var fieldsMetadata = new Dictionary<int, string>();
            for (_fieldsCount = 0; _fieldsCount < xmlSchema.Tables[tableName].Columns.Count; ++_fieldsCount)
            {
                var fieldName = xmlSchema.Tables[tableName].Columns[_fieldsCount].ColumnName;
                fieldsMetadata.Add(_fieldsCount, fieldName);
            }

            return fieldsMetadata;
        }

        private Dictionary<int, string> GetLineMetadata(XElement xElement)
        {
            var currentLineMetadata = new Dictionary<int, string>();

            int pos = 0;
            foreach (var attribute in xElement.Attributes())
            {
                currentLineMetadata.Add(pos, attribute.Name.ToString());
                ++pos;
            }

            return currentLineMetadata;
        }

        private object[] GetLineValues(XElement xElement)
        {
            var values = new object[_fieldsCount];
            foreach (var attribute in xElement.Attributes())
            {
                var attributeName = attribute.Name.ToString();
                var indexToPut = GetOrdinal(attributeName);

                values[indexToPut] = attribute.Value;
            }

            return values;
        }

        #region Implemented

        private int _fieldsCount;
        public int FieldCount
        {
            get { return _fieldsCount; }
        }

        public bool Read()
        {
            if (_xmlReader.EOF)
                return false;

            bool isBreak = false;
            while (_xmlReader.Read())
            {
                switch (_xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (_xmlReader.Name == _tableName)
                        {
                            XElement el = XElement.ReadFrom(_xmlReader) as XElement;
                            if (el != null)
                            {
                                _currentLineValues = GetLineValues(el);
                                isBreak = true;
                            }
                        }
                        break;
                }

                if (isBreak)
                    break;
            }

            return true; //_xmlReader.Read();
           
            /* something should be
            _xmlReader.Read();
            _xmlReader.

            _currentLine = _streamReader.ReadLine();

             В случае, если значения будут содержать символ ";" это работать не будет,
             и придется использовать более сложный алгоритм разбора.
            _currentLineValues = _currentLine.Split(';');

            var invalidRow = false;
            for (int i = 0; i < _currentLineValues.Length; i++)
            {
                if (!_constraintsTable[i](_currentLineValues[i]))
                {
                    invalidRow = true;
                    break;
                }
            }

            return !invalidRow || Read();
            */
        }

        public string GetName(int i)
        {
            return _fieldsMetadata[i];
        }

        public int GetOrdinal(string name)
        {
            return _fieldsMetadata
                .FirstOrDefault(f => f.Value == name).Key;
        }

        public object GetValue(int i)
        {
            return _currentLineValues[i];
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            _xmlReader.Close();
        }

        public void Dispose()
        {
            _xmlReader.Dispose();
        }

        #endregion


        #region Not implemented

        public int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public object this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
