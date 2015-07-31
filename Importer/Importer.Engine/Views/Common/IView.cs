
namespace Importer.Engine.Views.Common
{
    public enum ProgressStyle { Blocks, Marguee };
    /// <summary>
    /// common interface for all views
    /// </summary>
    public interface IView
    {
        // shows message (error, warning, notice)
        void ShowNoticeMessage(string message);
        void ShowWarningMessage(string message);
        void ShowErrorMessage(string message);

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
