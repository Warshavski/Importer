
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
    }
}
