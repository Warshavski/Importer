using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Importer.UI.WinView.Forms.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            const int total = 100000;
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < total; ++i)
            {
                worker.ReportProgress(i * 100 / total);
            }
            /*
            BackgroundWorker worker = sender as BackgroundWorker;
            string connectionString = string.Format(
              @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 8.0; HDR=YES'; ",
              @"D:\ЖНВЛП\JNVLP29072015.xls");

            DataTable dtTest = new DataTable();

            string commandText = "SELECT * FROM 'лист 1$'";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (var reader = new OleDbCommand(commandText, conn).ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        ++i;
                        worker.ReportProgress(i);
                        //reader.
                    }
                }
            }
            */
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
    }
}
