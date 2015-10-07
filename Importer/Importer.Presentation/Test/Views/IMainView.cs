using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Importer.Engine.Test.Files;

/* TODO : 
 *  1. Create interfaces for views (if view uses custom classes from model)
 
 */

namespace Importer.Presentation.Test.Views
{
    public interface IMainView
    {
        event Action DataLoad;
        
        Dictionary<string, string> FilesList { get; set; }
        //File TestFile { get; set; }
    }
}
