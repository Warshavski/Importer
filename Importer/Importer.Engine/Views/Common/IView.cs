
namespace Importer.Engine.Views.Common
{
    /// <summary>
    ///     common interface for all views
    /// </summary>
    public interface IView
    {
        // show message (error, warning, notice)
        void ShowNoticeMessage(string message);
        void ShowWarningMessage(string message);
        void ShowErrorMessage(string message);

        bool IsLoading { get; set; }
        //void Show();
        //void Close();
    }
}
