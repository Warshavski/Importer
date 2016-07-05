using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escyug.Importer.Presentations.BETA.Common;
using Escyug.Importer.Presentations.BETA.Views;
using Escyug.Importer.Presentations.BETA.Presenters;

namespace Escyug.Importer.WinForms.App
{
    static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IMainView, MainForm>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<MainPresenter>();
        }
    }
}
