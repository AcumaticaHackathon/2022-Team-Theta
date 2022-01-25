
namespace FileMigrator
{
    partial class Form1
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
            this.txtFolderLocation = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.GroupBox();
            this.txtEndPoint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAcumaticaURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtPswrd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolderLocation
            // 
            this.txtFolderLocation.Location = new System.Drawing.Point(99, 7);
            this.txtFolderLocation.Name = "txtFolderLocation";
            this.txtFolderLocation.Size = new System.Drawing.Size(568, 20);
            this.txtFolderLocation.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(591, 33);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "UPLOAD";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder Location";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(510, 33);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFolder.TabIndex = 4;
            this.btnFolder.Text = "FOLDER";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Controls.Add(this.txtEndPoint);
            this.txtPassword.Controls.Add(this.label6);
            this.txtPassword.Controls.Add(this.txtAcumaticaURL);
            this.txtPassword.Controls.Add(this.label5);
            this.txtPassword.Controls.Add(this.txtCompany);
            this.txtPassword.Controls.Add(this.txtPswrd);
            this.txtPassword.Controls.Add(this.label4);
            this.txtPassword.Controls.Add(this.txtUsername);
            this.txtPassword.Controls.Add(this.label2);
            this.txtPassword.Controls.Add(this.label3);
            this.txtPassword.Location = new System.Drawing.Point(15, 33);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(489, 148);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TabStop = false;
            this.txtPassword.Text = "Acumatica Logon";
            // 
            // txtEndPoint
            // 
            this.txtEndPoint.Location = new System.Drawing.Point(65, 41);
            this.txtEndPoint.Name = "txtEndPoint";
            this.txtEndPoint.Size = new System.Drawing.Size(418, 20);
            this.txtEndPoint.TabIndex = 14;
            this.txtEndPoint.Text = "/entity/TTFileManagement/20.200.001/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "EndPoint";
            // 
            // txtAcumaticaURL
            // 
            this.txtAcumaticaURL.Location = new System.Drawing.Point(65, 19);
            this.txtAcumaticaURL.Name = "txtAcumaticaURL";
            this.txtAcumaticaURL.Size = new System.Drawing.Size(418, 20);
            this.txtAcumaticaURL.TabIndex = 12;
            this.txtAcumaticaURL.Text = "http://localhost/AcumaticaERP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Site";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(65, 122);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(196, 20);
            this.txtCompany.TabIndex = 10;
            this.txtCompany.Text = "Company";
            // 
            // txtPswrd
            // 
            this.txtPswrd.Location = new System.Drawing.Point(65, 94);
            this.txtPswrd.Name = "txtPswrd";
            this.txtPswrd.Size = new System.Drawing.Size(196, 20);
            this.txtPswrd.TabIndex = 9;
            this.txtPswrd.Text = "Password@1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Company";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(65, 67);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(196, 20);
            this.txtUsername.TabIndex = 8;
            this.txtUsername.Text = "admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 220);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtFolderLocation);
            this.Name = "Form1";
            this.Text = "Acumatica Batch File Uploader";
            this.txtPassword.ResumeLayout(false);
            this.txtPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolderLocation;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.GroupBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPswrd;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtAcumaticaURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndPoint;
        private System.Windows.Forms.Label label6;
    }
}

