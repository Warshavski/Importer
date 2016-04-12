using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Escyug.Importer.Data.Xml.Prototype
{
    public abstract class XmlDataReader : IDataReader
    {
        private readonly string _rowElementName;

        private readonly XmlReader _xmlReader;
        private readonly int _fieldCount = -1;

        private bool _disposed;

        protected IEnumerator<XElement> _enumerator;

        public abstract object GetValue(int i);

        public XmlDataReader(XmlReader xmlReader, int fieldCount, string rowElementName)
        {
            _rowElementName = rowElementName;
            _fieldCount = fieldCount;
            _xmlReader = xmlReader;
            _enumerator = GetXmlStream().GetEnumerator();
        }

        private IEnumerable<XElement> GetXmlStream()
        {
            XElement rowElement;
            using (_xmlReader)
            {
                _xmlReader.MoveToContent();

                while (_xmlReader.Read())
                {
                    if (IsRowElement())
                    {
                        rowElement = XElement.ReadFrom(_xmlReader) as XElement;

                        if (rowElement != null)
                        {
                            yield return rowElement;
                        }
                    }
                }
            }
        }

        private bool IsRowElement()
        {
            if (_xmlReader.NodeType != XmlNodeType.Element)
                return false;

            return _xmlReader.Name == _rowElementName;
        }

        protected virtual void Dispose()
        {
            if (_disposed)
                return;
            _enumerator.Dispose();
            _disposed = true;
        }

        public bool Read()
        {
            return _enumerator.MoveNext();
        }

        public int FieldCount
        {
            get { return _fieldCount; }
        }

        public XElement CurrentElement
        {
            get { return _enumerator.Current; }
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

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

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
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

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
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
    }
}
