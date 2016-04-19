namespace Escyug.Importer.UI.WindowsFormsApp
{
    partial class MappingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSourceTables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSourceTables
            // 
            this.comboBoxSourceTables.FormattingEnabled = true;
            this.comboBoxSourceTables.Location = new System.Drawing.Point(117, 31);
            this.comboBoxSourceTables.Name = "comboBoxSourceTables";
            this.comboBoxSourceTables.Size = new System.Drawing.Size(177, 21);
            this.comboBoxSourceTables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source tables : ";
            // 
            // MappingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSourceTables);
            this.Name = "MappingsForm";
            this.Text = "MappingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSourceTables;
        private System.Windows.Forms.Label label1;
    }
}