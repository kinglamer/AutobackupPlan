namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    partial class frmProfile
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
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbSMTP = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tbOperator = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес почты с которой отправляем";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SMTP сервер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пользователь";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пароль";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(207, 16);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(183, 20);
            this.tbEmail.TabIndex = 4;
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbEmail_Validating);
            // 
            // tbSMTP
            // 
            this.tbSMTP.Location = new System.Drawing.Point(207, 39);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.Size = new System.Drawing.Size(183, 20);
            this.tbSMTP.TabIndex = 5;
            this.tbSMTP.Validating += new System.ComponentModel.CancelEventHandler(this.tbSMTP_Validating);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(207, 61);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(183, 20);
            this.tbUser.TabIndex = 6;
            this.tbUser.Validating += new System.ComponentModel.CancelEventHandler(this.tbUser_Validating);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(207, 85);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(183, 20);
            this.tbPass.TabIndex = 7;
            this.tbPass.Validating += new System.ComponentModel.CancelEventHandler(this.tbPass_Validating);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(234, 137);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 8;
            this.btAdd.Text = "Настроить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(315, 137);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 9;
            this.btClose.Text = "Отмена";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbOperator
            // 
            this.tbOperator.Location = new System.Drawing.Point(207, 111);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.Size = new System.Drawing.Size(183, 20);
            this.tbOperator.TabIndex = 12;
            this.tbOperator.Validating += new System.ComponentModel.CancelEventHandler(this.tbOperator_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Имя оператора в системе";
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 167);
            this.Controls.Add(this.tbOperator);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbSMTP);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProfile";
            this.Text = "Настройка профиля для отправки почты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbSMTP;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbOperator;
        private System.Windows.Forms.Label label5;
    }
}