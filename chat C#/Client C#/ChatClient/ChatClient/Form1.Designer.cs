namespace ChatClient
{
    partial class frmChatClient
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
            this.txtChatContent = new System.Windows.Forms.TextBox();
            this.txtChatText = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChatContent
            // 
            this.txtChatContent.Location = new System.Drawing.Point(1, 3);
            this.txtChatContent.Multiline = true;
            this.txtChatContent.Name = "txtChatContent";
            this.txtChatContent.ReadOnly = true;
            this.txtChatContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChatContent.Size = new System.Drawing.Size(469, 305);
            this.txtChatContent.TabIndex = 0;
            // 
            // txtChatText
            // 
            this.txtChatText.Location = new System.Drawing.Point(1, 323);
            this.txtChatText.Name = "txtChatText";
            this.txtChatText.Size = new System.Drawing.Size(408, 22);
            this.txtChatText.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(415, 309);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(55, 49);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmChatClient
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 361);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtChatText);
            this.Controls.Add(this.txtChatContent);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChatClient";
            this.Text = "Chat Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChatClient_FormClosing);
            this.Load += new System.EventHandler(this.frmChatClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChatContent;
        private System.Windows.Forms.TextBox txtChatText;
        private System.Windows.Forms.Button btnSend;
    }
}

