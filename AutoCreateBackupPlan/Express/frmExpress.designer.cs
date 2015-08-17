namespace AutoCreateBackupPlan.Express
{
    partial class frmExpress
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
            this.btInstall = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btGetP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btGetP2 = new System.Windows.Forms.Button();
            this.tbPath2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.cbHours = new System.Windows.Forms.ComboBox();
            this.cbMinutes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btInstall
            // 
            this.btInstall.Location = new System.Drawing.Point(150, 326);
            this.btInstall.Name = "btInstall";
            this.btInstall.Size = new System.Drawing.Size(75, 23);
            this.btInstall.TabIndex = 0;
            this.btInstall.Text = "Настроить";
            this.btInstall.UseVisualStyleBackColor = true;
            this.btInstall.Click += new System.EventHandler(this.btInstall_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(231, 326);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 1;
            this.btExit.Text = "Назад";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(12, 26);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(272, 20);
            this.tbPath.TabIndex = 2;
            // 
            // btGetP
            // 
            this.btGetP.Location = new System.Drawing.Point(290, 23);
            this.btGetP.Name = "btGetP";
            this.btGetP.Size = new System.Drawing.Size(27, 23);
            this.btGetP.TabIndex = 3;
            this.btGetP.Text = "...";
            this.btGetP.UseVisualStyleBackColor = true;
            this.btGetP.Click += new System.EventHandler(this.btGetPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Путь сохранения бэкапов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Путь до bat файла";
            // 
            // btGetP2
            // 
            this.btGetP2.Location = new System.Drawing.Point(290, 67);
            this.btGetP2.Name = "btGetP2";
            this.btGetP2.Size = new System.Drawing.Size(27, 23);
            this.btGetP2.TabIndex = 6;
            this.btGetP2.Text = "...";
            this.btGetP2.UseVisualStyleBackColor = true;
            this.btGetP2.Click += new System.EventHandler(this.btGetP2_Click);
            // 
            // tbPath2
            // 
            this.tbPath2.Location = new System.Drawing.Point(12, 67);
            this.tbPath2.Name = "tbPath2";
            this.tbPath2.Size = new System.Drawing.Size(272, 20);
            this.tbPath2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Логин для соединения с БД";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(12, 110);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(272, 20);
            this.tbUser.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Пароль для соединения";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(12, 156);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(272, 20);
            this.tbPass.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Сервер";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(12, 202);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(272, 20);
            this.tbServer.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Название БД";
            // 
            // tbOwner
            // 
            this.tbOwner.Location = new System.Drawing.Point(12, 244);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.Size = new System.Drawing.Size(272, 20);
            this.tbOwner.TabIndex = 14;
            // 
            // cbHours
            // 
            this.cbHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHours.FormattingEnabled = true;
            this.cbHours.Location = new System.Drawing.Point(56, 19);
            this.cbHours.Name = "cbHours";
            this.cbHours.Size = new System.Drawing.Size(70, 21);
            this.cbHours.TabIndex = 16;
            // 
            // cbMinutes
            // 
            this.cbMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinutes.FormattingEnabled = true;
            this.cbMinutes.Location = new System.Drawing.Point(184, 19);
            this.cbMinutes.Name = "cbMinutes";
            this.cbMinutes.Size = new System.Drawing.Size(70, 21);
            this.cbMinutes.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Часы";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Минуты";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHours);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbMinutes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(15, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 53);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Время начало создания бэкапа";
            // 
            // frmExpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbOwner);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btGetP2);
            this.Controls.Add(this.tbPath2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGetP);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btInstall);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExpress";
            this.Text = "Настройка бэкапа для SQLEXPRESS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btInstall;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btGetP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGetP2;
        private System.Windows.Forms.TextBox tbPath2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOwner;
        private System.Windows.Forms.ComboBox cbHours;
        private System.Windows.Forms.ComboBox cbMinutes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

