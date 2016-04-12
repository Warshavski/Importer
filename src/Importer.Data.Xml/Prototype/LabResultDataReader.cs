using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Escyug.Importer.Data.Xml.Prototype
{
    public static class MyExtensions
    {
        public static T EnumFromValue<T>(this XAttribute attribute)
        {
            string value = attribute.Value;
            if (string.IsNullOrEmpty(value))
                return default(T);

            try
            {
                T converted = (T)Enum.Parse(typeof(T), value, true);
                return converted;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
    
    public class LabResultDataReader : XmlDataReader
    {
        private const string XmlTagRow = "result";

        private const int FieldCount = 4;
        private const int InvalidItemId = -1;

        public LabResultDataReader(XmlReader xmlReader)
            : base(xmlReader, FieldCount, XmlTagRow) { }

        public override object GetValue(int i)
        {
            switch (i)
            {
                case 0:
                    //return CurrentElement.Attribute("type").EnumFromValue<ResultType>();
                case 1:
                    //return CurrentElement.Attribute("origin").EnumFromValue<Origin>();
                case 2:
                    return CurrentElement.Element("name").Value;
                case 3:
                    return CurrentElement.Element("description").Value;
                default:

                    throw new InvalidOperationException("Column count mismatch.");
            }
        }
    }


}

