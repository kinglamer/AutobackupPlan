namespace AutoCreateBackupPlan.Standart
{
    partial class frmSystemEmailSend
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSmtpServer = new System.Windows.Forms.TextBox();
            this.tbSMTPPort = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbToWho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пользователь почты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "SMTP Port";
            // 
            // tbSmtpServer
            // 
            this.tbSmtpServer.Location = new System.Drawing.Point(130, 5);
            this.tbSmtpServer.Name = "tbSmtpServer";
            this.tbSmtpServer.Size = new System.Drawing.Size(287, 20);
            this.tbSmtpServer.TabIndex = 4;
            // 
            // tbSMTPPort
            // 
            this.tbSMTPPort.Location = new System.Drawing.Point(130, 31);
            this.tbSMTPPort.Name = "tbSMTPPort";
            this.tbSMTPPort.Size = new System.Drawing.Size(287, 20);
            this.tbSMTPPort.TabIndex = 5;
            this.tbSMTPPort.Text = "25";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(130, 57);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(287, 20);
            this.tbLogin.TabIndex = 6;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(130, 83);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(287, 20);
            this.tbPass.TabIndex = 7;
            // 
            // tbToWho
            // 
            this.tbToWho.Location = new System.Drawing.Point(130, 109);
            this.tbToWho.Name = "tbToWho";
            this.tbToWho.Size = new System.Drawing.Size(287, 20);
            this.tbToWho.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Кому";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(261, 135);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 10;
            this.btSend.Text = "Отправить";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(342, 135);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "Выход";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmSystemEmailSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 171);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbToWho);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.tbSMTPPort);
            this.Controls.Add(this.tbSmtpServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSystemEmailSend";
            this.Text = "frmSystemEmailSend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSmtpServer;
        private System.Windows.Forms.TextBox tbSMTPPort;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbToWho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btClose;
    }
}