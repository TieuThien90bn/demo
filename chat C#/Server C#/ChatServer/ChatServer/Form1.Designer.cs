namespace ChatServer
{
    partial class frmServerMain
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lbPortListen = new System.Windows.Forms.Label();
            this.txtPortListener = new System.Windows.Forms.TextBox();
            this.txtServerLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(294, 3);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(110, 33);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // lbPortListen
            // 
            this.lbPortListen.AutoSize = true;
            this.lbPortListen.Location = new System.Drawing.Point(12, 12);
            this.lbPortListen.Name = "lbPortListen";
            this.lbPortListen.Size = new System.Drawing.Size(78, 15);
            this.lbPortListen.TabIndex = 1;
            this.lbPortListen.Text = "Port Listener:";
            // 
            // txtPortListener
            // 
            this.txtPortListener.Location = new System.Drawing.Point(96, 9);
            this.txtPortListener.Name = "txtPortListener";
            this.txtPortListener.Size = new System.Drawing.Size(192, 22);
            this.txtPortListener.TabIndex = 2;
            this.txtPortListener.Text = "1900";
            // 
            // txtServerLog
            // 
            this.txtServerLog.Location = new System.Drawing.Point(12, 42);
            this.txtServerLog.Multiline = true;
            this.txtServerLog.Name = "txtServerLog";
            this.txtServerLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServerLog.Size = new System.Drawing.Size(392, 306);
            this.txtServerLog.TabIndex = 3;
            // 
            // frmServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 360);
            this.Controls.Add(this.txtServerLog);
            this.Controls.Add(this.txtPortListener);
            this.Controls.Add(this.lbPortListen);
            this.Controls.Add(this.btnStartServer);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmServerMain";
            this.Text = "Chat Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServerMain_FormClosing);
            this.Load += new System.EventHandler(this.frmServerMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Label lbPortListen;
        private System.Windows.Forms.TextBox txtPortListener;
        private System.Windows.Forms.TextBox txtServerLog;
    }
}

