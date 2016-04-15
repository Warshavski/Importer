namespace Escyug.Importer.UI.WindowsFormsApp
{
    partial class MainForm
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
            this.listBoxConnectionStrings = new System.Windows.Forms.ListBox();
            this.lblListCsTitle = new System.Windows.Forms.Label();
            this.buttonLoadSource = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonDestinationLoad = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // listBoxConnectionStrings
            // 
            this.listBoxConnectionStrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxConnectionStrings.FormattingEnabled = true;
            this.listBoxConnectionStrings.Location = new System.Drawing.Point(12, 39);
            this.listBoxConnectionStrings.MinimumSize = new System.Drawing.Size(100, 50);
            this.listBoxConnectionStrings.Name = "listBoxConnectionStrings";
            this.listBoxConnectionStrings.Size = new System.Drawing.Size(513, 147);
            this.listBoxConnectionStrings.TabIndex = 0;
            // 
            // lblListCsTitle
            // 
            this.lblListCsTitle.AutoSize = true;
            this.lblListCsTitle.Location = new System.Drawing.Point(12, 23);
            this.lblListCsTitle.Name = "lblListCsTitle";
            this.lblListCsTitle.Size = new System.Drawing.Size(100, 13);
            this.lblListCsTitle.TabIndex = 1;
            this.lblListCsTitle.Text = "Connection strings :";
            // 
            // buttonLoadSource
            // 
            this.buttonLoadSource.Location = new System.Drawing.Point(12, 192);
            this.buttonLoadSource.Name = "buttonLoadSource";
            this.buttonLoadSource.Size = new System.Drawing.Size(90, 23);
            this.buttonLoadSource.TabIndex = 2;
            this.buttonLoadSource.Text = "Load source";
            this.buttonLoadSource.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 221);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(253, 179);
            this.treeView1.TabIndex = 3;
            // 
            // buttonDestinationLoad
            // 
            this.buttonDestinationLoad.Location = new System.Drawing.Point(272, 192);
            this.buttonDestinationLoad.Name = "buttonDestinationLoad";
            this.buttonDestinationLoad.Size = new System.Drawing.Size(157, 23);
            this.buttonDestinationLoad.TabIndex = 4;
            this.buttonDestinationLoad.Text = "Load destination";
            this.buttonDestinationLoad.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(272, 221);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(253, 179);
            this.treeView2.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 412);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.buttonDestinationLoad);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonLoadSource);
            this.Controls.Add(this.lblListCsTitle);
            this.Controls.Add(this.listBoxConnectionStrings);
            this.MinimumSize = new System.Drawing.Size(200, 250);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConnectionStrings;
        private System.Windows.Forms.Label lblListCsTitle;
        private System.Windows.Forms.Button buttonLoadSource;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonDestinationLoad;
        private System.Windows.Forms.TreeView treeView2;
    }
}