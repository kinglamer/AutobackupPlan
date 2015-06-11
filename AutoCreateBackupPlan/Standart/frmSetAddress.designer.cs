namespace AutoCreateBackupPlan.Standart
{
    partial class frmSetAddress
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
            this.btConnect = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.btTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(127, 121);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(78, 23);
            this.btConnect.TabIndex = 11;
            this.btConnect.Text = "Соединение";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(211, 121);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 12;
            this.btClose.Text = "Выход";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Адрес сервера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название БД";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Логин MS SQL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Пароль MS SQL";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(137, 18);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(119, 20);
            this.tbServer.TabIndex = 1;
            this.tbServer.Validating += new System.ComponentModel.CancelEventHandler(this.tbServer_Validating);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(137, 44);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(119, 20);
            this.tbUser.TabIndex = 2;
            this.tbUser.Validating += new System.ComponentModel.CancelEventHandler(this.tbUser_Validating);
            // 
            // tbOwner
            // 
            this.tbOwner.Location = new System.Drawing.Point(137, 96);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.Size = new System.Drawing.Size(119, 20);
            this.tbOwner.TabIndex = 4;
            this.tbOwner.Validating += new System.ComponentModel.CancelEventHandler(this.tbOwner_Validating);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(137, 70);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(119, 20);
            this.tbPass.TabIndex = 3;
            this.tbPass.Validating += new System.ComponentModel.CancelEventHandler(this.tbPass_Validating);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(12, 121);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(78, 23);
            this.btTest.TabIndex = 9;
            this.btTest.Text = "Проверить";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // frmSetAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 156);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbOwner);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSetAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Соединение с сервером MS SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbOwner;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button btTest;
    }
}