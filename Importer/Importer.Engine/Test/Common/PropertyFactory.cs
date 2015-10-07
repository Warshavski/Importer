using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Engine.Test.Common;

namespace Importer.Engine.Test.Common
{
    public sealed class PropertyFactory
    {
        private PropertyFactory() { }

        public PropertyInfo[] Create(string type)
        {
            switch (type)
            { 
                case "Sql" :
                    return new PropertyInfo[] {  };
                case "Excel" :
                    return new PropertyInfo[] 
                    {
                        new PropertyInfo("Microsoft Excel 97-2003",
                            "Excel 8.0; HDR=YES;"),
                        new PropertyInfo("Microsoft Excel 2007",
                            "Excel 12.0 Xml; HDR=YES;")
                    };
                case "Dbf" :
                    return new PropertyInfo[] 
                    {
                        new PropertyInfo ("dBase IV", "dBASE IV")
                    };
                default :
                    return null;
            }
            
        }
    }
}
