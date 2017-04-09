namespace SFTP
{
    partial class frmSFTPMain
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
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHostAddress = new System.Windows.Forms.TextBox();
            this.lbPortNumber = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbHostAddress = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.grpBody = new System.Windows.Forms.GroupBox();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtBrowser = new System.Windows.Forms.TextBox();
            this.btnListFile = new System.Windows.Forms.Button();
            this.grpHeader.SuspendLayout();
            this.grpBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.btnConnect);
            this.grpHeader.Controls.Add(this.txtUserName);
            this.grpHeader.Controls.Add(this.txtPortNumber);
            this.grpHeader.Controls.Add(this.txtPassword);
            this.grpHeader.Controls.Add(this.txtHostAddress);
            this.grpHeader.Controls.Add(this.lbPortNumber);
            this.grpHeader.Controls.Add(this.lbPassword);
            this.grpHeader.Controls.Add(this.lbHostAddress);
            this.grpHeader.Controls.Add(this.lbUserName);
            this.grpHeader.Location = new System.Drawing.Point(4, 4);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(656, 115);
            this.grpHeader.TabIndex = 0;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "System Information";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(543, 63);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(103, 34);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(325, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(126, 22);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.Location = new System.Drawing.Point(98, 71);
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(126, 22);
            this.txtPortNumber.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(325, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // txtHostAddress
            // 
            this.txtHostAddress.Location = new System.Drawing.Point(98, 34);
            this.txtHostAddress.Name = "txtHostAddress";
            this.txtHostAddress.Size = new System.Drawing.Size(126, 22);
            this.txtHostAddress.TabIndex = 0;
            // 
            // lbPortNumber
            // 
            this.lbPortNumber.AutoSize = true;
            this.lbPortNumber.Location = new System.Drawing.Point(8, 78);
            this.lbPortNumber.Name = "lbPortNumber";
            this.lbPortNumber.Size = new System.Drawing.Size(77, 15);
            this.lbPortNumber.TabIndex = 3;
            this.lbPortNumber.Text = "Port Number:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(242, 78);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(62, 15);
            this.lbPassword.TabIndex = 2;
            this.lbPassword.Text = "Password:";
            // 
            // lbHostAddress
            // 
            this.lbHostAddress.AutoSize = true;
            this.lbHostAddress.Location = new System.Drawing.Point(8, 41);
            this.lbHostAddress.Name = "lbHostAddress";
            this.lbHostAddress.Size = new System.Drawing.Size(84, 15);
            this.lbHostAddress.TabIndex = 1;
            this.lbHostAddress.Text = "Host Address:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(242, 41);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(68, 15);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "User Name:";
            // 
            // grpBody
            // 
            this.grpBody.Controls.Add(this.btnListFile);
            this.grpBody.Controls.Add(this.btnDownloadFile);
            this.grpBody.Controls.Add(this.btnUpload);
            this.grpBody.Controls.Add(this.txtLog);
            this.grpBody.Controls.Add(this.btnBrowser);
            this.grpBody.Controls.Add(this.txtBrowser);
            this.grpBody.Location = new System.Drawing.Point(4, 122);
            this.grpBody.Name = "grpBody";
            this.grpBody.Size = new System.Drawing.Size(656, 343);
            this.grpBody.TabIndex = 1;
            this.grpBody.TabStop = false;
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(543, 151);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(103, 28);
            this.btnDownloadFile.TabIndex = 3;
            this.btnDownloadFile.Text = "Download File";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(543, 117);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(103, 28);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload File";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.Location = new System.Drawing.Point(11, 83);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(526, 252);
            this.txtLog.TabIndex = 4;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(543, 16);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(103, 30);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browser...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtBrowser
            // 
            this.txtBrowser.Location = new System.Drawing.Point(11, 21);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.Size = new System.Drawing.Size(526, 22);
            this.txtBrowser.TabIndex = 0;
            // 
            // btnListFile
            // 
            this.btnListFile.Location = new System.Drawing.Point(543, 83);
            this.btnListFile.Name = "btnListFile";
            this.btnListFile.Size = new System.Drawing.Size(103, 28);
            this.btnListFile.TabIndex = 5;
            this.btnListFile.Text = "List File";
            this.btnListFile.UseVisualStyleBackColor = true;
            this.btnListFile.Click += new System.EventHandler(this.btnListFile_Click);
            // 
            // frmSFTPMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 469);
            this.Controls.Add(this.grpBody);
            this.Controls.Add(this.grpHeader);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmSFTPMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFTP Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSFTPMain_FormClosing);
            this.Load += new System.EventHandler(this.frmSFTPMain_Load);
            this.grpHeader.ResumeLayout(false);
            this.grpHeader.PerformLayout();
            this.grpBody.ResumeLayout(false);
            this.grpBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpHeader;
        private System.Windows.Forms.GroupBox grpBody;
        private System.Windows.Forms.Label lbPortNumber;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbHostAddress;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPortNumber;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHostAddress;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtBrowser;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnListFile;
    }
}

