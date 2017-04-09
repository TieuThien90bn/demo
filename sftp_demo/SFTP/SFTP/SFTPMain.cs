using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFTP
{
    public partial class frmSFTPMain : Form
    {
        //u can use 2 variable
        //port let connect to sftp server
        private int m_iPort = 22;

        //creating class that u have just created with all function
        private SftpProtocol m_sftpProtocol = null;

        public frmSFTPMain()
        {
            InitializeComponent();
        }

        private void frmSFTPMain_Load(object sender, EventArgs e)
        {
            appendLog("Loading form and init...");
            initControl();
            this.m_sftpProtocol = new SftpProtocol();

            //creating tool tip text for controls
            createToolTipText(this.txtHostAddress, "Host address server");
            createToolTipText(this.txtPortNumber, "Port nummber between 0 and 65535");
            createToolTipText(this.txtUserName, "User name let login SFTP server");
            createToolTipText(this.txtPassword, "Password let login SFTP server");
            appendLog("Finished loading form and init...");
        }

        private void createToolTipText(Control c, String s)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(c, s);
        }

        private void initControl()
        {
            //init controls
            this.grpHeader.Enabled = true;
            this.grpBody.Enabled = false;

            this.btnConnect.Text = "Connect";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // checking when clicking on connect button
            if (this.btnConnect.Equals("Disconnect"))
            {
                //this function let append text in log text box
                appendLog("Disconnect to server " + this.txtHostAddress.Text);
                this.m_sftpProtocol.close();
                initControl();
                appendLog("Disonnect to server " + this.txtHostAddress.Text + " finished");
            }
                //if u want to connect to sftp server firstly u need validate parameter
            else if (validateParam())
            {
                //after validate parameter
                appendLog("Connect to server " + this.txtHostAddress.Text);

                //connect to sftp server
                bool blConnectResult = this.m_sftpProtocol.connectSftpServer(this.txtHostAddress.Text,
                    this.m_iPort, this.txtUserName.Text, this.txtPassword.Text, 120);
                if (!blConnectResult)
                {
                    //connect failed, u can get error by getErrorDes  function
                    MessageBox.Show(this.m_sftpProtocol.getErrorDes(),
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    appendLog("Connect to server " + this.txtHostAddress.Text + " error");
                }
                else
                {
                    //connect true, init again form
                    this.grpHeader.Enabled = false;
                    this.grpBody.Enabled = true;
                    appendLog("Connected to server " + this.txtHostAddress.Text );
                }
            }
        }

        private void appendLog(String strContent)
        {
            this.txtLog.AppendText(strContent + "\r\n");
        }
        private Boolean validateParam()
        {
            bool blResult = true;

            //in hrere we will have some variable let validate ads bellow
            if (this.txtHostAddress.Text.Trim().Equals("")
                || this.txtPortNumber.Text.Trim().Equals("")
                || this.txtUserName.Text.Trim().Equals("")
                || this.txtPassword.Text.Trim().Equals(""))
            {
                //show warning box
                MessageBox.Show("Please fill all information let connect to server!",
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                blResult = false;
            }
            else
            {
                try
                {
                    //validate port
                    this.m_iPort = Convert.ToInt32(this.txtPortNumber.Text);
                    if (this.m_iPort < 1 && this.m_iPort > 65535)
                    {
                        MessageBox.Show("Port nummber have to be nummeric between 0 and 65535, please try again!",
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blResult = false;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Port nummber have to be integer, please try again!",
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blResult = false;
                }
            }
            return blResult;
        }

        private void frmSFTPMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //beforing close u should close sftp session let free session on sftp server
            this.m_sftpProtocol.close();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            //this button let u choose file let upload, or let set dir let list file, download file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            String strFileName = openFileDialog.FileName;

            if (strFileName != null && !strFileName.Equals(""))
            {
                this.txtBrowser.Text = strFileName;
            }
            else
            {
                MessageBox.Show("Please choosing a file let continue!",
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool blResult = false;

            //in here u can call uplaod file function
            if (!this.txtBrowser.Text.Trim().Equals(""))
            {
                String[] arrayFullFileName = this.txtBrowser.Text.Split('\\');
                String strFileName = arrayFullFileName[arrayFullFileName.Length - 1];

                appendLog("Uploading file " + this.txtBrowser.Text);

                //in here i use fix path /test let upload file
                blResult = this.m_sftpProtocol.uploadFile(this.txtBrowser.Text,"/test/" + strFileName,true);
                if (!blResult)
                {
                    MessageBox.Show(this.m_sftpProtocol.getErrorDes(),
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    appendLog("Uploading file " + this.txtBrowser.Text + " error" );
                }
                else
                {
                    appendLog("Uploading file " + this.txtBrowser.Text + " successed" );
                }
            }
            else
            {
                MessageBox.Show("Please choosing a file let continue!",
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            bool blResult = false;

            //this button let download file, before download file u can choose path let save file
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.ShowDialog();
            
            if (saveFileDialog.FileName != null && 
                !saveFileDialog.FileName.Equals("")
                && !this.txtBrowser.Text.Trim().Equals(""))
            {
                //after validate file let saving into path u can call download file function
                appendLog("Downloading file " + this.txtBrowser.Text);

                //text box browser is used to make path on sftp server let download file
                blResult = this.m_sftpProtocol.downloadFile(this.txtBrowser.Text, saveFileDialog.FileName);
                if (!blResult)
                {
                    MessageBox.Show(this.m_sftpProtocol.getErrorDes(),
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    appendLog("Downloading file " + this.txtBrowser.Text + " error");
                }
                else
                {
                    appendLog("Downloading file " + this.txtBrowser.Text + " successed");
                }
            }
            else
            {
                MessageBox.Show("Please choosing a file let continue!",
                    "SFTP Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnListFile_Click(object sender, EventArgs e)
        {
            //this button will provide to u function let list file
            //in this function file path will be input via browser text box
            IEnumerable < Renci.SshNet.Sftp.SftpFile > lsFile = this.m_sftpProtocol.listFile(this.txtBrowser.Text);

            if (lsFile != null)
            {
                appendLog("List all file from path: /\r\n");
                foreach (Renci.SshNet.Sftp.SftpFile sftpFile in lsFile)
                {
                    appendLog("List File: " + sftpFile.FullName + "\r\n");
                }
                appendLog("List all file from path: / finished\r\n");
            }
            else
            {
                appendLog("Can not find any file " + this.m_sftpProtocol.getErrorDes() + ".");
            }
        }
    }
}
