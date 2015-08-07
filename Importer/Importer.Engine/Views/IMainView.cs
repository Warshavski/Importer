using System.Collections.Generic;
using Importer.Engine.Models;
using Importer.Engine.Views.Common;
using Importer.Engine.Models.Importers;

namespace Importer.Engine.Views
{
    /// <summary>
    /// interface for main view
    /// </summary>
    public interface IMainView : IView, ILoading
    {
        // list of supported file types
        List<ICreator> FileTypesList { get; set; }

        // list of extended properties for each supported file type
        PropertyInfo[] ExtendedProperties { get; set; }
        // store selected extedted propertie
        PropertyInfo SelectedProperty { get; set; }

        // list of source tables for each supported file type (when source is initialized)
        List<Table> SourceTablesList { get; set; }
        // store selected source table
        Table SelectedSourceTable { get; set; }

        // list of target tables 
        List<Table> TargetTablesList { get; set; }
        // store selected target table
        Table SelectedTargetTable { get; set; }

        // list of columns for each table (when source file is initialized)
        List<Column> SourceTableColumnsList { get; set; }
        List<Column> TargetTableColumnsList { get; set; }
        
        // store selected file type
        ICreator SelectedSourceFileType { get; set; }

        // sets true - if needed to truncate table, false - if not
        bool IsTruncate { get; set; }

        // path to file 
        string FilePath { get; set; }

        // column mappings
        List<ColumnsMapping> Mappings { get; set; }
    }
}
