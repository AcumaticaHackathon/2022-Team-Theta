using FileMigrator.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileMigrator.Integration;
using System.IO;

namespace FileMigrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Encryption Certificates
        //Callback, which is used to validate the certificate of
        //an Acumatica ERP website in an SSL conversation
        private static bool ValidateRemoteCertificate(object sender,
        X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            //For simplicity, this callback always returns true.
            //In a real integration application, you must check an SSL
            //certificate here.
            return true;
        }
        #endregion

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolderLocation.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
            string result = "#Processing...";
            using (RestService rs = new RestService(txtAcumaticaURL.Text, txtEndPoint.Text))
            {
                //Log in to Acumatica ERP
                string logonStatus = rs.Login(txtUsername.Text, txtPswrd.Text, txtCompany.Text, null);

                if (logonStatus == "OK")
                {
                    try
                    {
                        string[] fileEntries = Directory.GetFiles(txtFolderLocation.Text);

                        foreach (string file in fileEntries) 
                        {
                            FileInfo fi = new FileInfo(file);

                            string id = FileProcessor.ProcessDocument(rs, fi.FullName, fi.Name, Convert.ToDecimal(fi.Length / 1000), "Open", fi.DirectoryName, txtUsername.Text);
                            FileProcessor.AddFilesToTransaction(rs, id, fi.FullName,fi.Name, "DataFile");
                        
                        }
                    }
                    catch (Exception error)
                    {
                        result = "#" + error.Message;
                    }
                    finally
                    {
                        rs.Logout();
                    }
                }
                else
                {
                    rs.Logout();
                    MessageBox.Show("Authorisation with the Acumatica EndPoints could not be establised, please try again.", "Logon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
