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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxConnectionStrings = new System.Windows.Forms.ListBox();
            this.lblListCsTitle = new System.Windows.Forms.Label();
            this.buttonLoadSource = new System.Windows.Forms.Button();
            this.buttonDestinationLoad = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmBoxFilesTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMetadata = new System.Windows.Forms.DataGridView();
            this.sourceNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmBoxSourceTables = new System.Windows.Forms.ComboBox();
            this.buttonImportExecute = new System.Windows.Forms.Button();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetadata)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxConnectionStrings
            // 
            this.listBoxConnectionStrings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxConnectionStrings.FormattingEnabled = true;
            this.listBoxConnectionStrings.Location = new System.Drawing.Point(5, 88);
            this.listBoxConnectionStrings.MinimumSize = new System.Drawing.Size(100, 50);
            this.listBoxConnectionStrings.Name = "listBoxConnectionStrings";
            this.listBoxConnectionStrings.Size = new System.Drawing.Size(773, 147);
            this.listBoxConnectionStrings.TabIndex = 0;
            // 
            // lblListCsTitle
            // 
            this.lblListCsTitle.AutoSize = true;
            this.lblListCsTitle.Location = new System.Drawing.Point(9, 72);
            this.lblListCsTitle.Name = "lblListCsTitle";
            this.lblListCsTitle.Size = new System.Drawing.Size(100, 13);
            this.lblListCsTitle.TabIndex = 1;
            this.lblListCsTitle.Text = "Connection strings :";
            // 
            // buttonLoadSource
            // 
            this.buttonLoadSource.Location = new System.Drawing.Point(5, 241);
            this.buttonLoadSource.Name = "buttonLoadSource";
            this.buttonLoadSource.Size = new System.Drawing.Size(90, 23);
            this.buttonLoadSource.TabIndex = 2;
            this.buttonLoadSource.Text = "Load source";
            this.buttonLoadSource.UseVisualStyleBackColor = true;
            // 
            // buttonDestinationLoad
            // 
            this.buttonDestinationLoad.Location = new System.Drawing.Point(101, 241);
            this.buttonDestinationLoad.Name = "buttonDestinationLoad";
            this.buttonDestinationLoad.Size = new System.Drawing.Size(157, 23);
            this.buttonDestinationLoad.TabIndex = 4;
            this.buttonDestinationLoad.Text = "Load destination";
            this.buttonDestinationLoad.UseVisualStyleBackColor = true;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(525, 379);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(253, 179);
            this.treeView2.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(790, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "Status...";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmBoxFilesTypes
            // 
            this.cmBoxFilesTypes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmBoxFilesTypes.FormattingEnabled = true;
            this.cmBoxFilesTypes.Location = new System.Drawing.Point(70, 43);
            this.cmBoxFilesTypes.Name = "cmBoxFilesTypes";
            this.cmBoxFilesTypes.Size = new System.Drawing.Size(200, 21);
            this.cmBoxFilesTypes.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "File type : ";
            // 
            // dgvMetadata
            // 
            this.dgvMetadata.AllowUserToAddRows = false;
            this.dgvMetadata.AllowUserToDeleteRows = false;
            this.dgvMetadata.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvMetadata.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMetadata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetadata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sourceNameColumn,
            this.sourceDataTypeColumn,
            this.sourceLength});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMetadata.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMetadata.Location = new System.Drawing.Point(5, 301);
            this.dgvMetadata.MultiSelect = false;
            this.dgvMetadata.Name = "dgvMetadata";
            this.dgvMetadata.ReadOnly = true;
            this.dgvMetadata.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMetadata.RowHeadersVisible = false;
            this.dgvMetadata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMetadata.Size = new System.Drawing.Size(305, 257);
            this.dgvMetadata.TabIndex = 10;
            // 
            // sourceNameColumn
            // 
            this.sourceNameColumn.DataPropertyName = "Name";
            this.sourceNameColumn.HeaderText = "Name";
            this.sourceNameColumn.Name = "sourceNameColumn";
            this.sourceNameColumn.ReadOnly = true;
            // 
            // sourceDataTypeColumn
            // 
            this.sourceDataTypeColumn.DataPropertyName = "Type";
            this.sourceDataTypeColumn.HeaderText = "Data type";
            this.sourceDataTypeColumn.Name = "sourceDataTypeColumn";
            this.sourceDataTypeColumn.ReadOnly = true;
            // 
            // sourceLength
            // 
            this.sourceLength.DataPropertyName = "Length";
            this.sourceLength.HeaderText = "Length";
            this.sourceLength.Name = "sourceLength";
            this.sourceLength.ReadOnly = true;
            // 
            // cmBoxSourceTables
            // 
            this.cmBoxSourceTables.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmBoxSourceTables.FormattingEnabled = true;
            this.cmBoxSourceTables.Location = new System.Drawing.Point(5, 274);
            this.cmBoxSourceTables.Name = "cmBoxSourceTables";
            this.cmBoxSourceTables.Size = new System.Drawing.Size(253, 21);
            this.cmBoxSourceTables.TabIndex = 11;
            // 
            // buttonImportExecute
            // 
            this.buttonImportExecute.Location = new System.Drawing.Point(593, 241);
            this.buttonImportExecute.Name = "buttonImportExecute";
            this.buttonImportExecute.Size = new System.Drawing.Size(185, 23);
            this.buttonImportExecute.TabIndex = 12;
            this.buttonImportExecute.Text = "Import test";
            this.buttonImportExecute.UseVisualStyleBackColor = true;
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(36, 22);
            this.toolStripDropDownButton2.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(41, 22);
            this.toolStripDropDownButton1.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 583);
            this.Controls.Add(this.buttonImportExecute);
            this.Controls.Add(this.cmBoxSourceTables);
            this.Controls.Add(this.dgvMetadata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmBoxFilesTypes);
            this.Controls.Add(this.listBoxConnectionStrings);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.buttonDestinationLoad);
            this.Controls.Add(this.buttonLoadSource);
            this.Controls.Add(this.lblListCsTitle);
            this.MinimumSize = new System.Drawing.Size(200, 250);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetadata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConnectionStrings;
        private System.Windows.Forms.Label lblListCsTitle;
        private System.Windows.Forms.Button buttonLoadSource;
        private System.Windows.Forms.Button buttonDestinationLoad;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmBoxFilesTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMetadata;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceLength;
        private System.Windows.Forms.ComboBox cmBoxSourceTables;
        private System.Windows.Forms.Button buttonImportExecute;
    }
}