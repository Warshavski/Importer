
namespace Importer.Engine.Models
{
    internal class DbfCreator : ICreator
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        internal DbfCreator()
        { 
        
        }

        #region Члены ICreator

        private const string DISPLAY_NAME = "Dbf files";
        public string DisplayName
        {
            get { return DISPLAY_NAME; }
        }

        private const FileBrowse FILE_BROWSE_TYPE = FileBrowse.Folder;
        public FileBrowse FileBrowse
        {
            get { return FILE_BROWSE_TYPE; }
        }

        public PropertyInfo[] GetProperties()
        {
            return new PropertyInfo[] 
            {
                new PropertyInfo ("dBase IV", "dBASE IV")
            };
        }

        public IFile CreateInstance(string filePath, PropertyInfo property)
        {
            // create and return DbfFile instance 
            return new DbfFile(filePath, property);
        }

        #endregion
    }
}
