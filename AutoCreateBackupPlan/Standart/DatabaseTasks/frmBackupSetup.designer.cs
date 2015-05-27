namespace AutoCreateBackupPlan.Standart.DatabaseTasks
{
    partial class frmBackupSetup
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
            this.btAdd = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btPathFull = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMSDB = new System.Windows.Forms.TextBox();
            this.tbFull = new System.Windows.Forms.TextBox();
            this.tbDiff = new System.Windows.Forms.TextBox();
            this.tbTran = new System.Windows.Forms.TextBox();
            this.tbMaster = new System.Windows.Forms.TextBox();
            this.btPathDiff = new System.Windows.Forms.Button();
            this.btPathTran = new System.Windows.Forms.Button();
            this.btPathMaster = new System.Windows.Forms.Button();
            this.btPathMSDB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(313, 230);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Сохранить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(394, 230);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Закрыть";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btPathFull
            // 
            this.btPathFull.Location = new System.Drawing.Point(435, 30);
            this.btPathFull.Name = "btPathFull";
            this.btPathFull.Size = new System.Drawing.Size(29, 23);
            this.btPathFull.TabIndex = 2;
            this.btPathFull.Text = "...";
            this.btPathFull.UseVisualStyleBackColor = true;
            this.btPathFull.Click += new System.EventHandler(this.btPathFull_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Хранилище полных копий Дело";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Хранилище разностных копий Дело";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Хранилище журналов транзакций Дело";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Хранилище полной копии master";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Хранилище полной копии msdb";
            // 
            // tbMSDB
            // 
            this.tbMSDB.Location = new System.Drawing.Point(20, 199);
            this.tbMSDB.Name = "tbMSDB";
            this.tbMSDB.Size = new System.Drawing.Size(413, 20);
            this.tbMSDB.TabIndex = 12;
            this.tbMSDB.Validating += new System.ComponentModel.CancelEventHandler(this.tbMSDB_Validating);
            // 
            // tbFull
            // 
            this.tbFull.Location = new System.Drawing.Point(20, 32);
            this.tbFull.Name = "tbFull";
            this.tbFull.Size = new System.Drawing.Size(413, 20);
            this.tbFull.TabIndex = 13;
            this.tbFull.Validating += new System.ComponentModel.CancelEventHandler(this.tbFull_Validating);
            // 
            // tbDiff
            // 
            this.tbDiff.Location = new System.Drawing.Point(20, 74);
            this.tbDiff.Name = "tbDiff";
            this.tbDiff.Size = new System.Drawing.Size(413, 20);
            this.tbDiff.TabIndex = 14;
            this.tbDiff.Validating += new System.ComponentModel.CancelEventHandler(this.tbDiff_Validating);
            // 
            // tbTran
            // 
            this.tbTran.Location = new System.Drawing.Point(20, 113);
            this.tbTran.Name = "tbTran";
            this.tbTran.Size = new System.Drawing.Size(413, 20);
            this.tbTran.TabIndex = 15;
            this.tbTran.Validating += new System.ComponentModel.CancelEventHandler(this.tbTran_Validating);
            // 
            // tbMaster
            // 
            this.tbMaster.Location = new System.Drawing.Point(20, 151);
            this.tbMaster.Name = "tbMaster";
            this.tbMaster.Size = new System.Drawing.Size(413, 20);
            this.tbMaster.TabIndex = 16;
            this.tbMaster.Validating += new System.ComponentModel.CancelEventHandler(this.tbMaster_Validating);
            // 
            // btPathDiff
            // 
            this.btPathDiff.Location = new System.Drawing.Point(435, 71);
            this.btPathDiff.Name = "btPathDiff";
            this.btPathDiff.Size = new System.Drawing.Size(29, 23);
            this.btPathDiff.TabIndex = 17;
            this.btPathDiff.Text = "...";
            this.btPathDiff.UseVisualStyleBackColor = true;
            this.btPathDiff.Click += new System.EventHandler(this.btPathDiff_Click);
            // 
            // btPathTran
            // 
            this.btPathTran.Location = new System.Drawing.Point(435, 113);
            this.btPathTran.Name = "btPathTran";
            this.btPathTran.Size = new System.Drawing.Size(29, 23);
            this.btPathTran.TabIndex = 18;
            this.btPathTran.Text = "...";
            this.btPathTran.UseVisualStyleBackColor = true;
            this.btPathTran.Click += new System.EventHandler(this.btPathTran_Click);
            // 
            // btPathMaster
            // 
            this.btPathMaster.Location = new System.Drawing.Point(435, 149);
            this.btPathMaster.Name = "btPathMaster";
            this.btPathMaster.Size = new System.Drawing.Size(29, 23);
            this.btPathMaster.TabIndex = 19;
            this.btPathMaster.Text = "...";
            this.btPathMaster.UseVisualStyleBackColor = true;
            this.btPathMaster.Click += new System.EventHandler(this.btPathMaster_Click);
            // 
            // btPathMSDB
            // 
            this.btPathMSDB.Location = new System.Drawing.Point(435, 197);
            this.btPathMSDB.Name = "btPathMSDB";
            this.btPathMSDB.Size = new System.Drawing.Size(29, 23);
            this.btPathMSDB.TabIndex = 20;
            this.btPathMSDB.Text = "...";
            this.btPathMSDB.UseVisualStyleBackColor = true;
            this.btPathMSDB.Click += new System.EventHandler(this.btPathMSDB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmBackupSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btPathMSDB);
            this.Controls.Add(this.btPathMaster);
            this.Controls.Add(this.btPathTran);
            this.Controls.Add(this.btPathDiff);
            this.Controls.Add(this.tbMaster);
            this.Controls.Add(this.tbTran);
            this.Controls.Add(this.tbDiff);
            this.Controls.Add(this.tbFull);
            this.Controls.Add(this.tbMSDB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btPathFull);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAdd);
            this.Name = "frmBackupSetup";
            this.Text = "Настройка хранения копий";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btPathFull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMSDB;
        private System.Windows.Forms.TextBox tbFull;
        private System.Windows.Forms.TextBox tbDiff;
        private System.Windows.Forms.TextBox tbTran;
        private System.Windows.Forms.TextBox tbMaster;
        private System.Windows.Forms.Button btPathDiff;
        private System.Windows.Forms.Button btPathTran;
        private System.Windows.Forms.Button btPathMaster;
        private System.Windows.Forms.Button btPathMSDB;
        private System.Windows.Forms.Button button1;
    }
}