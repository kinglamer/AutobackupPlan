namespace AutoCreateBackupPlan.Standart
{
    partial class frmStandart
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStandart));
            this.btCreateNotify = new System.Windows.Forms.Button();
            this.iList = new System.Windows.Forms.ImageList(this.components);
            this.btInstall = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btSetupDatabaseMail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCreateNotify
            // 
            this.btCreateNotify.ImageKey = "radar.png";
            this.btCreateNotify.ImageList = this.iList;
            this.btCreateNotify.Location = new System.Drawing.Point(202, 163);
            this.btCreateNotify.Name = "btCreateNotify";
            this.btCreateNotify.Size = new System.Drawing.Size(76, 65);
            this.btCreateNotify.TabIndex = 3;
            this.btCreateNotify.UseVisualStyleBackColor = true;
            this.btCreateNotify.Click += new System.EventHandler(this.btCreateNotify_Click);
            // 
            // iList
            // 
            this.iList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iList.ImageStream")));
            this.iList.TransparentColor = System.Drawing.Color.Transparent;
            this.iList.Images.SetKeyName(0, "Tools 4.ico");
            this.iList.Images.SetKeyName(1, "export1.png");
            this.iList.Images.SetKeyName(2, "install.png");
            this.iList.Images.SetKeyName(3, "delete.png");
            this.iList.Images.SetKeyName(4, "radar.png");
            this.iList.Images.SetKeyName(5, "contacts.png");
            // 
            // btInstall
            // 
            this.btInstall.ImageKey = "install.png";
            this.btInstall.ImageList = this.iList;
            this.btInstall.Location = new System.Drawing.Point(202, 89);
            this.btInstall.Name = "btInstall";
            this.btInstall.Size = new System.Drawing.Size(76, 68);
            this.btInstall.TabIndex = 5;
            this.btInstall.UseVisualStyleBackColor = true;
            this.btInstall.Click += new System.EventHandler(this.btInstall_Click);
            // 
            // btDelete
            // 
            this.btDelete.ImageKey = "delete.png";
            this.btDelete.ImageList = this.iList;
            this.btDelete.Location = new System.Drawing.Point(202, 234);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(76, 69);
            this.btDelete.TabIndex = 6;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Настроить резервное копирование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Удалить задачи из БД";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Создать системные задачи";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbLog);
            this.groupBox1.Location = new System.Drawing.Point(301, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 240);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Лог выполнения задач";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(6, 19);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(349, 211);
            this.rtbLog.TabIndex = 10;
            this.rtbLog.Text = "";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(587, 328);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 12;
            this.btClose.Text = "Выход";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSetupDatabaseMail
            // 
            this.btSetupDatabaseMail.ImageKey = "contacts.png";
            this.btSetupDatabaseMail.ImageList = this.iList;
            this.btSetupDatabaseMail.Location = new System.Drawing.Point(202, 15);
            this.btSetupDatabaseMail.Name = "btSetupDatabaseMail";
            this.btSetupDatabaseMail.Size = new System.Drawing.Size(76, 68);
            this.btSetupDatabaseMail.TabIndex = 13;
            this.btSetupDatabaseMail.UseVisualStyleBackColor = true;
            this.btSetupDatabaseMail.Click += new System.EventHandler(this.btSetupDatabaseMail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Настроить DatabaseMail";
            // 
            // frmStandart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 363);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSetupDatabaseMail);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btInstall);
            this.Controls.Add(this.btCreateNotify);
            this.Name = "frmStandart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Модуль настройки резервного копирования";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCreateNotify;
        private System.Windows.Forms.Button btInstall;
        private System.Windows.Forms.ImageList iList;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSetupDatabaseMail;
        private System.Windows.Forms.Label label4;
    }
}

