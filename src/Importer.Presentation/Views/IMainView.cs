using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escyug.Importer.Models;

namespace Escyug.Importer.Presentations.Views
{
    public interface IMainView
    {
        IDataInstance SourceDataInstance { get; set; }
        IDataInstance DestinationDataInstance { get; set; }

        event Action SourceInstanceLoad;
        event Action DestinationInstanceLoad;
    }
}
