namespace Importer.UI.WinView.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grBoxSourceFile = new System.Windows.Forms.GroupBox();
            this.txtBoxFilePath = new System.Windows.Forms.TextBox();
            this.cmBoxSourceFileTypes = new System.Windows.Forms.ComboBox();
            this.chBoxTruncate = new System.Windows.Forms.CheckBox();
            this.lblSourceFileTypes = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblExtendedProperty = new System.Windows.Forms.Label();
            this.cmBoxExtendedProperty = new System.Windows.Forms.ComboBox();
            this.grBoxTargetFile = new System.Windows.Forms.GroupBox();
            this.btnShowSourceData = new System.Windows.Forms.Button();
            this.lblTargetFileType = new System.Windows.Forms.Label();
            this.cmBoxTargetFileTypes = new System.Windows.Forms.ComboBox();
            this.lblSourceTable = new System.Windows.Forms.Label();
            this.cmBoxSourceTablesList = new System.Windows.Forms.ComboBox();
            this.btnTargetFileSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmBoxTargetTablesList = new System.Windows.Forms.ComboBox();
            this.lblTargetTable = new System.Windows.Forms.Label();
            this.btnShowTargetData = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grBoxSourceFile.SuspendLayout();
            this.grBoxTargetFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.statusStripButtonCancel});
            this.statusStripMain.Location = new System.Drawing.Point(0, 420);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(661, 22);
            this.statusStripMain.TabIndex = 23;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonFile,
            this.toolStripSeparator1,
            this.toolStripDropDownButtonHelp});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(661, 25);
            this.toolStripMain.TabIndex = 22;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grBoxTargetFile);
            this.pnlMain.Controls.Add(this.chBoxTruncate);
            this.pnlMain.Controls.Add(this.grBoxSourceFile);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(661, 395);
            this.pnlMain.TabIndex = 1;
            // 
            // grBoxSourceFile
            // 
            this.grBoxSourceFile.Controls.Add(this.cmBoxSourceTablesList);
            this.grBoxSourceFile.Controls.Add(this.lblSourceTable);
            this.grBoxSourceFile.Controls.Add(this.btnShowSourceData);
            this.grBoxSourceFile.Controls.Add(this.lblExtendedProperty);
            this.grBoxSourceFile.Controls.Add(this.cmBoxExtendedProperty);
            this.grBoxSourceFile.Controls.Add(this.cmBoxSourceFileTypes);
            this.grBoxSourceFile.Controls.Add(this.lblSourceFileTypes);
            this.grBoxSourceFile.Controls.Add(this.lblFilePath);
            this.grBoxSourceFile.Controls.Add(this.txtBoxFilePath);
            this.grBoxSourceFile.Controls.Add(this.btnBrowse);
            this.grBoxSourceFile.Location = new System.Drawing.Point(6, 6);
            this.grBoxSourceFile.Name = "grBoxSourceFile";
            this.grBoxSourceFile.Size = new System.Drawing.Size(283, 235);
            this.grBoxSourceFile.TabIndex = 2;
            this.grBoxSourceFile.TabStop = false;
            this.grBoxSourceFile.Text = "Source file :";
            // 
            // txtBoxFilePath
            // 
            this.txtBoxFilePath.Location = new System.Drawing.Point(20, 86);
            this.txtBoxFilePath.Name = "txtBoxFilePath";
            this.txtBoxFilePath.Size = new System.Drawing.Size(150, 20);
            this.txtBoxFilePath.TabIndex = 6;
            // 
            // cmBoxSourceFileTypes
            // 
            this.cmBoxSourceFileTypes.FormattingEnabled = true;
            this.cmBoxSourceFileTypes.Location = new System.Drawing.Point(20, 42);
            this.cmBoxSourceFileTypes.Name = "cmBoxSourceFileTypes";
            this.cmBoxSourceFileTypes.Size = new System.Drawing.Size(150, 21);
            this.cmBoxSourceFileTypes.TabIndex = 4;
            // 
            // chBoxTruncate
            // 
            this.chBoxTruncate.AutoSize = true;
            this.chBoxTruncate.Location = new System.Drawing.Point(6, 375);
            this.chBoxTruncate.Name = "chBoxTruncate";
            this.chBoxTruncate.Size = new System.Drawing.Size(125, 17);
            this.chBoxTruncate.TabIndex = 21;
            this.chBoxTruncate.Text = "Truncate target table";
            this.chBoxTruncate.UseVisualStyleBackColor = true;
            // 
            // lblSourceFileTypes
            // 
            this.lblSourceFileTypes.AutoSize = true;
            this.lblSourceFileTypes.Location = new System.Drawing.Point(17, 26);
            this.lblSourceFileTypes.Name = "lblSourceFileTypes";
            this.lblSourceFileTypes.Size = new System.Drawing.Size(55, 13);
            this.lblSourceFileTypes.TabIndex = 3;
            this.lblSourceFileTypes.Text = "File type : ";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(176, 84);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripDropDownButtonFile
            // 
            this.toolStripDropDownButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButtonFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonFile.Image")));
            this.toolStripDropDownButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFile.Name = "toolStripDropDownButtonFile";
            this.toolStripDropDownButtonFile.Size = new System.Drawing.Size(36, 22);
            this.toolStripDropDownButtonFile.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButtonHelp
            // 
            this.toolStripDropDownButtonHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonHelp.Image")));
            this.toolStripDropDownButtonHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonHelp.Name = "toolStripDropDownButtonHelp";
            this.toolStripDropDownButtonHelp.Size = new System.Drawing.Size(41, 22);
            this.toolStripDropDownButtonHelp.Text = "Help";
            // 
            // statusStripButtonCancel
            // 
            this.statusStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.statusStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("statusStripButtonCancel.Image")));
            this.statusStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusStripButtonCancel.Name = "statusStripButtonCancel";
            this.statusStripButtonCancel.Size = new System.Drawing.Size(23, 20);
            this.statusStripButtonCancel.Text = "toolStripButton1";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(17, 70);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(56, 13);
            this.lblFilePath.TabIndex = 5;
            this.lblFilePath.Text = "File path : ";
            // 
            // lblExtendedProperty
            // 
            this.lblExtendedProperty.AutoSize = true;
            this.lblExtendedProperty.Location = new System.Drawing.Point(17, 114);
            this.lblExtendedProperty.Name = "lblExtendedProperty";
            this.lblExtendedProperty.Size = new System.Drawing.Size(100, 13);
            this.lblExtendedProperty.TabIndex = 8;
            this.lblExtendedProperty.Text = "ExtendedProperty : ";
            // 
            // cmBoxExtendedProperty
            // 
            this.cmBoxExtendedProperty.FormattingEnabled = true;
            this.cmBoxExtendedProperty.Location = new System.Drawing.Point(20, 130);
            this.cmBoxExtendedProperty.Name = "cmBoxExtendedProperty";
            this.cmBoxExtendedProperty.Size = new System.Drawing.Size(150, 21);
            this.cmBoxExtendedProperty.TabIndex = 9;
            // 
            // grBoxTargetFile
            // 
            this.grBoxTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxTargetFile.Controls.Add(this.cmBoxTargetTablesList);
            this.grBoxTargetFile.Controls.Add(this.lblTargetTable);
            this.grBoxTargetFile.Controls.Add(this.button1);
            this.grBoxTargetFile.Controls.Add(this.btnShowTargetData);
            this.grBoxTargetFile.Controls.Add(this.btnTargetFileSettings);
            this.grBoxTargetFile.Controls.Add(this.cmBoxTargetFileTypes);
            this.grBoxTargetFile.Controls.Add(this.lblTargetFileType);
            this.grBoxTargetFile.Location = new System.Drawing.Point(301, 6);
            this.grBoxTargetFile.Name = "grBoxTargetFile";
            this.grBoxTargetFile.Size = new System.Drawing.Size(354, 235);
            this.grBoxTargetFile.TabIndex = 13;
            this.grBoxTargetFile.TabStop = false;
            this.grBoxTargetFile.Text = "Target file :";
            // 
            // btnShowSourceData
            // 
            this.btnShowSourceData.Location = new System.Drawing.Point(176, 192);
            this.btnShowSourceData.Name = "btnShowSourceData";
            this.btnShowSourceData.Size = new System.Drawing.Size(85, 23);
            this.btnShowSourceData.TabIndex = 12;
            this.btnShowSourceData.Text = "Show data";
            this.btnShowSourceData.UseVisualStyleBackColor = true;
            // 
            // lblTargetFileType
            // 
            this.lblTargetFileType.AutoSize = true;
            this.lblTargetFileType.Location = new System.Drawing.Point(17, 26);
            this.lblTargetFileType.Name = "lblTargetFileType";
            this.lblTargetFileType.Size = new System.Drawing.Size(55, 13);
            this.lblTargetFileType.TabIndex = 14;
            this.lblTargetFileType.Text = "File type : ";
            // 
            // cmBoxTargetFileTypes
            // 
            this.cmBoxTargetFileTypes.FormattingEnabled = true;
            this.cmBoxTargetFileTypes.Location = new System.Drawing.Point(20, 42);
            this.cmBoxTargetFileTypes.Name = "cmBoxTargetFileTypes";
            this.cmBoxTargetFileTypes.Size = new System.Drawing.Size(150, 21);
            this.cmBoxTargetFileTypes.TabIndex = 15;
            // 
            // lblSourceTable
            // 
            this.lblSourceTable.AutoSize = true;
            this.lblSourceTable.Location = new System.Drawing.Point(17, 178);
            this.lblSourceTable.Name = "lblSourceTable";
            this.lblSourceTable.Size = new System.Drawing.Size(76, 13);
            this.lblSourceTable.TabIndex = 10;
            this.lblSourceTable.Text = "Source table : ";
            // 
            // cmBoxSourceTablesList
            // 
            this.cmBoxSourceTablesList.FormattingEnabled = true;
            this.cmBoxSourceTablesList.Location = new System.Drawing.Point(20, 194);
            this.cmBoxSourceTablesList.Name = "cmBoxSourceTablesList";
            this.cmBoxSourceTablesList.Size = new System.Drawing.Size(150, 21);
            this.cmBoxSourceTablesList.TabIndex = 11;
            // 
            // btnTargetFileSettings
            // 
            this.btnTargetFileSettings.Location = new System.Drawing.Point(20, 84);
            this.btnTargetFileSettings.Name = "btnTargetFileSettings";
            this.btnTargetFileSettings.Size = new System.Drawing.Size(85, 23);
            this.btnTargetFileSettings.TabIndex = 16;
            this.btnTargetFileSettings.Text = "Settings";
            this.btnTargetFileSettings.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Load target table list";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmBoxTargetTablesList
            // 
            this.cmBoxTargetTablesList.FormattingEnabled = true;
            this.cmBoxTargetTablesList.Location = new System.Drawing.Point(20, 194);
            this.cmBoxTargetTablesList.Name = "cmBoxTargetTablesList";
            this.cmBoxTargetTablesList.Size = new System.Drawing.Size(150, 21);
            this.cmBoxTargetTablesList.TabIndex = 19;
            // 
            // lblTargetTable
            // 
            this.lblTargetTable.AutoSize = true;
            this.lblTargetTable.Location = new System.Drawing.Point(17, 178);
            this.lblTargetTable.Name = "lblTargetTable";
            this.lblTargetTable.Size = new System.Drawing.Size(73, 13);
            this.lblTargetTable.TabIndex = 18;
            this.lblTargetTable.Text = "Target table : ";
            // 
            // btnShowTargetData
            // 
            this.btnShowTargetData.Location = new System.Drawing.Point(176, 192);
            this.btnShowTargetData.Name = "btnShowTargetData";
            this.btnShowTargetData.Size = new System.Drawing.Size(85, 23);
            this.btnShowTargetData.TabIndex = 20;
            this.btnShowTargetData.Text = "Show data";
            this.btnShowTargetData.UseVisualStyleBackColor = true;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 442);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStripMain);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.grBoxSourceFile.ResumeLayout(false);
            this.grBoxSourceFile.PerformLayout();
            this.grBoxTargetFile.ResumeLayout(false);
            this.grBoxTargetFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grBoxSourceFile;
        private System.Windows.Forms.TextBox txtBoxFilePath;
        private System.Windows.Forms.ComboBox cmBoxSourceFileTypes;
        private System.Windows.Forms.CheckBox chBoxTruncate;
        private System.Windows.Forms.Label lblSourceFileTypes;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton statusStripButtonCancel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonHelp;
        private System.Windows.Forms.Label lblExtendedProperty;
        private System.Windows.Forms.ComboBox cmBoxExtendedProperty;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.GroupBox grBoxTargetFile;
        private System.Windows.Forms.ComboBox cmBoxTargetFileTypes;
        private System.Windows.Forms.Label lblTargetFileType;
        private System.Windows.Forms.Button btnShowSourceData;
        private System.Windows.Forms.ComboBox cmBoxSourceTablesList;
        private System.Windows.Forms.Label lblSourceTable;
        private System.Windows.Forms.ComboBox cmBoxTargetTablesList;
        private System.Windows.Forms.Label lblTargetTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowTargetData;
        private System.Windows.Forms.Button btnTargetFileSettings;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}