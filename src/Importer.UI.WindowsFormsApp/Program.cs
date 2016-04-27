using System;
using System.Windows.Forms;

using Escyug.Importer.Models.Services;

using Escyug.Importer.Presentations.Common;
using Escyug.Importer.Presentations.Presenters;
using Escyug.Importer.Presentations.Views;

using Escyug.Importer.UI.WindowsFormsApp.Setup;

namespace Escyug.Importer.UI.WindowsFormsApp
{
    internal static class Program
    {
        // ?? for what ??
        public static readonly ApplicationContext Context = new ApplicationContext();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"..\Importer.UI.WindowsFormsApp\App.config");

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IMainView, MainForm>()
                .RegisterView<ISqlSetupView, SqlSetupForm>()
                .RegisterView<IExcelSetupView, ExcelSetupForm>()
                .RegisterView<IDbfSetupView, DbfSetupForm>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<MainPresenter>();
        }
    }
}
