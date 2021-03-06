﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCreateBackupPlan.Common;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    public partial class frmProfile : Form
    {
        private UserData ud;
        public frmProfile()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            ud = UserData.Load(ClassConstHelper.fileConfigsStandart);
            if (ud.userEmailData != null)
            {
                tbEmail.Text = ud.userEmailData.SendEmail;
                tbSMTP.Text = ud.userEmailData.SmtpServer;
                tbUser.Text = ud.userEmailData.EmailUser;
                tbPass.Text = ud.userEmailData.EmailPassword;
                tbOperator.Text = ud.userEmailData.OperatorName;

                validEmail = validSmtp = validUser = validPass = validEmailOperator = true;
            }

        }

        public string   email_address { get; set; }
        public string   mailserver_name  { get; set; }
        public string   username { get; set; }
        public  string  password { get; set; }

        public string email_operator { get; set; }
        public bool CreateMail { get; set; }
        private ErrorProvider errorProvider1 = new ErrorProvider();


        private bool validEmail;
        private bool validSmtp;
        private bool validUser;
        private bool validPass;
        private bool validEmailOperator;

       




        private void btAdd_Click(object sender, EventArgs e)
        {
            if (validEmail && validSmtp && validUser && validPass && validEmailOperator)
            {
                email_address = tbEmail.Text;
                mailserver_name = tbSMTP.Text;
                username = tbUser.Text;
                password = tbPass.Text;
                email_operator = tbOperator.Text;


                ud.SetEmailData(new UserEmailData("", tbEmail.Text, tbSMTP.Text, tbUser.Text, tbPass.Text, tbOperator.Text));
                ud.Save(ClassConstHelper.fileConfigsStandart);

                CreateMail = true;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.Msg_ErrorValidFields);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            CreateMail = false;
            Close();
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;

            validEmail = ValidatorDatabaseMail.ValidEmailAddress(tbEmail.Text, out errorMsg);

            ValidatorDatabaseMail.AnalyValid(tbEmail, validEmail, errorMsg, errorProvider1);
        }

        private void tbSMTP_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validSmtp, errorProvider1);
        }

        private void tbUser_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validUser, errorProvider1);
           
        }

        private void tbPass_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validPass, errorProvider1);
        }

    
    

        private void tbOperator_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;

            validEmailOperator = ValidatorDatabaseMail.ValidEmailAddress(tbOperator.Text, out errorMsg);

            ValidatorDatabaseMail.AnalyValid(tbOperator, validEmailOperator, errorMsg, errorProvider1);
        }
    }
}
