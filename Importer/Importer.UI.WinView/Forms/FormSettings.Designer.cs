namespace Importer.UI.WinView.Forms
{
    partial class FormSettings
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
            this.grBoxTrust = new System.Windows.Forms.GroupBox();
            this.rbSqlTrust = new System.Windows.Forms.RadioButton();
            this.rbWindowsTrust = new System.Windows.Forms.RadioButton();
            this.pnlSqlTrust = new System.Windows.Forms.Panel();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbCatalogName = new System.Windows.Forms.TextBox();
            this.lblCatalogName = new System.Windows.Forms.Label();
            this.txtBoxServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.btnSaveProperties = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grBoxTrust.SuspendLayout();
            this.pnlSqlTrust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grBoxTrust
            // 
            this.grBoxTrust.Controls.Add(this.rbSqlTrust);
            this.grBoxTrust.Controls.Add(this.rbWindowsTrust);
            this.grBoxTrust.Controls.Add(this.pnlSqlTrust);
            this.grBoxTrust.Location = new System.Drawing.Point(15, 186);
            this.grBoxTrust.Name = "grBoxTrust";
            this.grBoxTrust.Size = new System.Drawing.Size(378, 150);
            this.grBoxTrust.TabIndex = 10;
            this.grBoxTrust.TabStop = false;
            this.grBoxTrust.Text = "Проверка подлинности :";
            // 
            // rbSqlTrust
            // 
            this.rbSqlTrust.AutoSize = true;
            this.rbSqlTrust.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSqlTrust.Location = new System.Drawing.Point(18, 51);
            this.rbSqlTrust.Name = "rbSqlTrust";
            this.rbSqlTrust.Size = new System.Drawing.Size(280, 18);
            this.rbSqlTrust.TabIndex = 3;
            this.rbSqlTrust.TabStop = true;
            this.rbSqlTrust.Text = "Использовать проверку подлинности SQL Server";
            this.rbSqlTrust.UseVisualStyleBackColor = true;
            this.rbSqlTrust.CheckedChanged += new System.EventHandler(this.EventHandler_Trust_CheckedChanged);
            // 
            // rbWindowsTrust
            // 
            this.rbWindowsTrust.AutoSize = true;
            this.rbWindowsTrust.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbWindowsTrust.Location = new System.Drawing.Point(18, 28);
            this.rbWindowsTrust.Name = "rbWindowsTrust";
            this.rbWindowsTrust.Size = new System.Drawing.Size(269, 18);
            this.rbWindowsTrust.TabIndex = 2;
            this.rbWindowsTrust.TabStop = true;
            this.rbWindowsTrust.Text = "Использовать проверку подлинности Windows";
            this.rbWindowsTrust.UseVisualStyleBackColor = true;
            this.rbWindowsTrust.CheckedChanged += new System.EventHandler(this.EventHandler_Trust_CheckedChanged);
            // 
            // pnlSqlTrust
            // 
            this.pnlSqlTrust.Controls.Add(this.txtBoxPass);
            this.pnlSqlTrust.Controls.Add(this.lblPass);
            this.pnlSqlTrust.Controls.Add(this.txtBoxUserName);
            this.pnlSqlTrust.Controls.Add(this.lblUserName);
            this.pnlSqlTrust.Location = new System.Drawing.Point(10, 77);
            this.pnlSqlTrust.Name = "pnlSqlTrust";
            this.pnlSqlTrust.Size = new System.Drawing.Size(358, 68);
            this.pnlSqlTrust.TabIndex = 11;
            // 
            // tbPass
            // 
            this.txtBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPass.Location = new System.Drawing.Point(126, 37);
            this.txtBoxPass.Name = "tbPass";
            this.txtBoxPass.Size = new System.Drawing.Size(221, 20);
            this.txtBoxPass.TabIndex = 5;
            this.txtBoxPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(11, 39);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(51, 13);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Пароль :";
            // 
            // tbUserName
            // 
            this.txtBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxUserName.Location = new System.Drawing.Point(126, 10);
            this.txtBoxUserName.Name = "tbUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(221, 20);
            this.txtBoxUserName.TabIndex = 4;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(11, 13);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(109, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Имя пользователя :";
            // 
            // tbCatalogName
            // 
            this.tbCatalogName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCatalogName.Location = new System.Drawing.Point(103, 155);
            this.tbCatalogName.Name = "tbCatalogName";
            this.tbCatalogName.Size = new System.Drawing.Size(200, 20);
            this.tbCatalogName.TabIndex = 1;
            // 
            // lblCatalogName
            // 
            this.lblCatalogName.AutoSize = true;
            this.lblCatalogName.Location = new System.Drawing.Point(17, 157);
            this.lblCatalogName.Name = "lblCatalogName";
            this.lblCatalogName.Size = new System.Drawing.Size(78, 13);
            this.lblCatalogName.TabIndex = 9;
            this.lblCatalogName.Text = "База данных :";
            // 
            // tbServerName
            // 
            this.txtBoxServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxServerName.Location = new System.Drawing.Point(103, 128);
            this.txtBoxServerName.Name = "tbServerName";
            this.txtBoxServerName.Size = new System.Drawing.Size(200, 20);
            this.txtBoxServerName.TabIndex = 0;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(17, 131);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(80, 13);
            this.lblServerName.TabIndex = 8;
            this.lblServerName.Text = "Имя сервера :";
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnect.Location = new System.Drawing.Point(15, 348);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(150, 25);
            this.btnTestConnect.TabIndex = 6;
            this.btnTestConnect.Tag = "test";
            this.btnTestConnect.Text = "Проверка соединения";
            this.btnTestConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.EventHandler_btnTestConnect_Click);
            // 
            // btnSaveProperties
            // 
            this.btnSaveProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveProperties.Location = new System.Drawing.Point(174, 348);
            this.btnSaveProperties.Name = "btnSaveProperties";
            this.btnSaveProperties.Size = new System.Drawing.Size(100, 25);
            this.btnSaveProperties.TabIndex = 7;
            this.btnSaveProperties.Tag = "save";
            this.btnSaveProperties.Text = "Сохранить";
            this.btnSaveProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSaveProperties.UseVisualStyleBackColor = true;
            this.btnSaveProperties.Click += new System.EventHandler(this.EventHandler_btnSaveProperties_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 102);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 383);
            this.Controls.Add(this.btnSaveProperties);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grBoxTrust);
            this.Controls.Add(this.tbCatalogName);
            this.Controls.Add(this.lblCatalogName);
            this.Controls.Add(this.txtBoxServerName);
            this.Controls.Add(this.lblServerName);
            this.MaximumSize = new System.Drawing.Size(415, 410);
            this.MinimumSize = new System.Drawing.Size(415, 410);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка подключения к SQL Server";
            this.grBoxTrust.ResumeLayout(false);
            this.grBoxTrust.PerformLayout();
            this.pnlSqlTrust.ResumeLayout(false);
            this.pnlSqlTrust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxTrust;
        private System.Windows.Forms.RadioButton rbSqlTrust;
        private System.Windows.Forms.RadioButton rbWindowsTrust;
        private System.Windows.Forms.Panel pnlSqlTrust;
        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbCatalogName;
        private System.Windows.Forms.Label lblCatalogName;
        private System.Windows.Forms.TextBox txtBoxServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveProperties;
        private System.Windows.Forms.Button btnTestConnect;
    }
}