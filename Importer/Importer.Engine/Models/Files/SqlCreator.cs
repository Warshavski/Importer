using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Models
{
    /* TODO :
     *   1. Create properties template
     */
    public class SqlCreator : ICreator
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public SqlCreator()
        { 
            
        }

        #region Члены ICreator

        private const string DISPLAY_NAME = "Sql server";
        public string DisplayName
        {
            get { return DISPLAY_NAME; }
        }

        private const FileBrowse FILE_BROWSE_TYPE = FileBrowse.None;
        public FileBrowse FileBrowse
        {
            get { return FILE_BROWSE_TYPE; }
        }
       
        public PropertyInfo[] GetProperties()
        {
            /******************************* Sql connection strings : *******************************
             *                                                                                      *
             *   Windows security : Data Source={source string}; Initial Catalog={catalog name};    *
             *        User={user name}; Password={password}; Integrated Security=True               *
             *                                                                                      *
             *  ----------------------------------------------------------------------------------  *
             *                                                                                      *
             *   Server security : Data Source={source string}; Initial Catalog={catalog name};     *
             *        User={user name}; Password={password};                                        *
             *                                                                                      *
             ****************************************************************************************/

            // create and return PropertyInfo array 
            return new PropertyInfo[]
            {
                // add values to array
                new PropertyInfo("Windows security", 
                    string.Format("Integrated Security=True")),
                new PropertyInfo("Server security", "")
            };
        }

        /// <summary>
        /// create instance of file
        /// </summary>
        /// <param name="filePath">DataSource and Catalog name</param>
        /// <param name="property">extended properties (windows or server security)</param>
        /// <returns>instance of SqlFile class</returns>
        public IFile CreateInstance(string filePath, PropertyInfo property)
        {
            // create and return new SqlFile instance
            return new SqlFile(filePath, property);
        }

        public IFile CreateInstance(string connectionString)
        {
            // create and return new SqlFile instance
            return new SqlFile(connectionString);
        }

        #endregion
    }
}

