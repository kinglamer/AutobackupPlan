namespace AutoCreateBackupPlan
{
    partial class frmMain
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
            this.btExpress = new System.Windows.Forms.Button();
            this.btStandart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btExpress
            // 
            this.btExpress.Location = new System.Drawing.Point(48, 23);
            this.btExpress.Name = "btExpress";
            this.btExpress.Size = new System.Drawing.Size(110, 23);
            this.btExpress.TabIndex = 0;
            this.btExpress.Text = "MS SQL Express";
            this.btExpress.UseVisualStyleBackColor = true;
            this.btExpress.Click += new System.EventHandler(this.btExpress_Click);
            // 
            // btStandart
            // 
            this.btStandart.Location = new System.Drawing.Point(190, 23);
            this.btStandart.Name = "btStandart";
            this.btStandart.Size = new System.Drawing.Size(110, 23);
            this.btStandart.TabIndex = 1;
            this.btStandart.Text = "MS SQL Standart";
            this.btStandart.UseVisualStyleBackColor = true;
            this.btStandart.Click += new System.EventHandler(this.btStandart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(354, 58);
            this.Controls.Add(this.btStandart);
            this.Controls.Add(this.btExpress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор версии MS SQL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btExpress;
        private System.Windows.Forms.Button btStandart;
    }
}

