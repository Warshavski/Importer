using System.Collections.Generic;
using Importer.Engine.Models;
using Importer.Engine.Views.Common;

namespace Importer.Engine.Views
{
    /// <summary>
    /// interface for main view
    /// </summary>
    public interface IMainView : IView
    {
        // list of supported file types
        IList<ICreator> FileTypesList { get; set; }

        // list of extended properties for each supported file type
        PropertyInfo[] ExtendedProperties { get; set; }
        // store selected extedted propertie
        PropertyInfo SelectedProperty { get; set; }

        // list of source tables for each supported file type (when source is initialized)
        IList<Table> SourceTablesList { get; set; }
        // store selected source table
        Table SelectedSourceTable { get; set; }

        // list of target tables 
        IList<Table> TargetTablesList { get; set; }
        // store selected target table
        Table SelectedTargetTable { get; set; }

        // list of columns for each table (when source file is initialized)
        IList<Column> SourceTableColumnsList { get; set; }
        IList<Column> TargetTableColumnsList { get; set; }
        
        // store selected file type
        ICreator SelectedSourceFileType { get; set; }

        // sets true - if needed to truncate table, false - if not
        bool IsTruncate { get; set; }

        // path to file 
        string FilePath { get; set; }
    }
}
