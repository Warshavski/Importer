
namespace Importer.Engine.Models
{
    internal class ExcelCreator : ICreator
    {
        /// <summary>
        /// Default construnctor
        /// </summary>
        internal ExcelCreator()
        { 
        
        }

        #region Члены ICreator

        private const string DISPLAY_NAME = "Excel files";
        public string DisplayName
        {
            get { return DISPLAY_NAME; }
        }

        private const FileBrowse FILE_BROWSE_TYPE = FileBrowse.File;
        public FileBrowse FileBrowse
        {
            get { return FILE_BROWSE_TYPE; }
        }

        public PropertyInfo[] GetProperties()
        {
            /************* Excel extended properties : *************
             *                                                     *
             *   Value :          "'Excel 8.0; HDR=YES'; "         *
             *   Display name :   "Microsoft Excel 97-2003"        *
             *                                                     *
             * --------------------------------------------------- *
             *                                                     *
             *   Value :          "'Excel 12.0 Xml; HDR=YES'; "    *
             *   Display name :   "Microsoft Excel 2007"           *
             *                                                     *
             * *****************************************************/

            return new PropertyInfo[] 
            {
                new PropertyInfo("Microsoft Excel 97-2003",
                    "'Excel 8.0; HDR=YES'; "),
                new PropertyInfo("Microsoft Excel 2007",
                    "'Excel 12.0 Xml; HDR=YES'; ")
            };
        }

        public IFile CreateInstance(string filePath, PropertyInfo property)
        {
            // create and return ExcelFile instance 
            return new ExcelFile(filePath, property);
        }

        #endregion
    }
}
