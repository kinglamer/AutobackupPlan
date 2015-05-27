using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    public partial class frmSendEmail : Form
    {
        public frmSendEmail()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public string email_address { get; set; }

        public bool SendMail { get; set; }
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private bool validEmail;

        private void btClose_Click(object sender, EventArgs e)
        {
            SendMail = false;
            Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (validEmail)
            {
                email_address = tbEmail.Text;


                SendMail = true;
                Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены корректно");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email_address = "budaev@biz-it.ru";
            SendMail = true;
            Close();
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {

            string errorMsg;

            validEmail = ValidatorDatabaseMail.ValidEmailAddress(tbEmail.Text, out errorMsg);

            ValidatorDatabaseMail.AnalyValid(tbEmail, validEmail, errorMsg, errorProvider1);
        }
    }
}
