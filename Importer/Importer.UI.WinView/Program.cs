using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Importer.UI.WinView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Importer.UI.WinView.Forms.FormMain());
        }
    }
}
