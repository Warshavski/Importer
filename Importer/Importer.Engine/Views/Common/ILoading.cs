using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Importer.Engine.Views.Common
{
    public interface ILoading
    {
        // indicates that some operations are executing
        bool IsLoading { get; set; }

        // style of progress indicator
        ProgressStyle ProgressBarStyle { get; set; }

        // text status of execution
        string ExecutionStatusText { get; set; }

        // numeric status of execution
        int ExecutionStatusValue { get; set; }
    }
}
