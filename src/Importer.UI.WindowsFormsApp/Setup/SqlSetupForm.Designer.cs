namespace Escyug.Importer.UI.WindowsFormsApp.Setup
{
    partial class SqlSetupForm
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
            this.labelServerName = new System.Windows.Forms.Label();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.groupBoxAuth = new System.Windows.Forms.GroupBox();
            this.panelSqlAuth = new System.Windows.Forms.Panel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.radioButtonSqlAuth = new System.Windows.Forms.RadioButton();
            this.radioButtonWindowsAuth = new System.Windows.Forms.RadioButton();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.buttonInitializeTest = new System.Windows.Forms.Button();
            this.textBoxDataBase = new System.Windows.Forms.TextBox();
            this.groupBoxAuth.SuspendLayout();
            this.panelSqlAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(7, 9);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(73, 13);
            this.labelServerName.TabIndex = 0;
            this.labelServerName.Text = "Server name :";
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Location = new System.Drawing.Point(116, 6);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(350, 20);
            this.textBoxServerName.TabIndex = 1;
            // 
            // groupBoxAuth
            // 
            this.groupBoxAuth.Controls.Add(this.panelSqlAuth);
            this.groupBoxAuth.Controls.Add(this.radioButtonSqlAuth);
            this.groupBoxAuth.Controls.Add(this.radioButtonWindowsAuth);
            this.groupBoxAuth.Location = new System.Drawing.Point(9, 59);
            this.groupBoxAuth.Name = "groupBoxAuth";
            this.groupBoxAuth.Size = new System.Drawing.Size(467, 138);
            this.groupBoxAuth.TabIndex = 2;
            this.groupBoxAuth.TabStop = false;
            this.groupBoxAuth.Text = "Authentication : ";
            // 
            // panelSqlAuth
            // 
            this.panelSqlAuth.Controls.Add(this.textBoxPassword);
            this.panelSqlAuth.Controls.Add(this.labelPassword);
            this.panelSqlAuth.Controls.Add(this.textBoxUserName);
            this.panelSqlAuth.Controls.Add(this.labelUserName);
            this.panelSqlAuth.Location = new System.Drawing.Point(31, 67);
            this.panelSqlAuth.Name = "panelSqlAuth";
            this.panelSqlAuth.Size = new System.Drawing.Size(428, 61);
            this.panelSqlAuth.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(110, 31);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(315, 20);
            this.textBoxPassword.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 34);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(62, 13);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password : ";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(110, 6);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(315, 20);
            this.textBoxUserName.TabIndex = 4;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(6, 9);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(67, 13);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User name : ";
            // 
            // radioButtonSqlAuth
            // 
            this.radioButtonSqlAuth.AutoSize = true;
            this.radioButtonSqlAuth.Location = new System.Drawing.Point(15, 44);
            this.radioButtonSqlAuth.Name = "radioButtonSqlAuth";
            this.radioButtonSqlAuth.Size = new System.Drawing.Size(150, 17);
            this.radioButtonSqlAuth.TabIndex = 1;
            this.radioButtonSqlAuth.TabStop = true;
            this.radioButtonSqlAuth.Text = "SQL Server authentication";
            this.radioButtonSqlAuth.UseVisualStyleBackColor = true;
            // 
            // radioButtonWindowsAuth
            // 
            this.radioButtonWindowsAuth.AutoSize = true;
            this.radioButtonWindowsAuth.Location = new System.Drawing.Point(15, 21);
            this.radioButtonWindowsAuth.Name = "radioButtonWindowsAuth";
            this.radioButtonWindowsAuth.Size = new System.Drawing.Size(139, 17);
            this.radioButtonWindowsAuth.TabIndex = 0;
            this.radioButtonWindowsAuth.TabStop = true;
            this.radioButtonWindowsAuth.Text = "Windows authentication";
            this.radioButtonWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(368, 30);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(98, 23);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Location = new System.Drawing.Point(7, 35);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(65, 13);
            this.labelDataBase.TabIndex = 7;
            this.labelDataBase.Text = "Data base : ";
            // 
            // buttonInitializeTest
            // 
            this.buttonInitializeTest.Location = new System.Drawing.Point(383, 203);
            this.buttonInitializeTest.Name = "buttonInitializeTest";
            this.buttonInitializeTest.Size = new System.Drawing.Size(90, 23);
            this.buttonInitializeTest.TabIndex = 9;
            this.buttonInitializeTest.Text = "Initialize test";
            this.buttonInitializeTest.UseVisualStyleBackColor = true;
            // 
            // textBoxDataBase
            // 
            this.textBoxDataBase.Location = new System.Drawing.Point(116, 32);
            this.textBoxDataBase.Name = "textBoxDataBase";
            this.textBoxDataBase.Size = new System.Drawing.Size(247, 20);
            this.textBoxDataBase.TabIndex = 10;
            // 
            // SqlSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 232);
            this.Controls.Add(this.textBoxDataBase);
            this.Controls.Add(this.buttonInitializeTest);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelDataBase);
            this.Controls.Add(this.groupBoxAuth);
            this.Controls.Add(this.textBoxServerName);
            this.Controls.Add(this.labelServerName);
            this.Name = "SqlSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlInstanceForm";
            this.groupBoxAuth.ResumeLayout(false);
            this.groupBoxAuth.PerformLayout();
            this.panelSqlAuth.ResumeLayout(false);
            this.panelSqlAuth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.GroupBox groupBoxAuth;
        private System.Windows.Forms.Panel panelSqlAuth;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.RadioButton radioButtonSqlAuth;
        private System.Windows.Forms.RadioButton radioButtonWindowsAuth;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.Button buttonInitializeTest;
        private System.Windows.Forms.TextBox textBoxDataBase;
    }
}