using AutoCreateBackupPlan.Standart.DatabaseMail;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart
{
    public partial class frmSetAddress : Form
    {
        public frmSetAddress()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        //TODO: написать сохранение последних введенных данных, чтобы не писать каждый раз заново


        private ErrorProvider errorProvider1 = new ErrorProvider();

        public bool ConnectReady { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }

        private bool validServer;
        private bool validOwner;
        private bool validUser;
        private bool validPass;

        private void btClose_Click(object sender, EventArgs e)
        {
            ConnectReady = false;
            Close();
        }

        private void tbServer_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validServer, errorProvider1);
        }

        private void tbOwner_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validOwner, errorProvider1);
        }

        private void tbUser_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validUser, errorProvider1);
        }

        private void tbPass_Validating(object sender, CancelEventArgs e)
        {
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validPass, errorProvider1);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (validOwner && validPass && validServer && validUser)
            {
                UserLogin = tbUser.Text;
                UserPass = tbPass.Text;

                ClassConstHelper.DB = tbOwner.Text;
                ClassConstHelper.serverSQL = tbServer.Text;

                ConnectReady = true;
                Close();
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все настройки");
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            //TODO: реализовать кнопку проверки соединения с БД и передалать место сохранения SQL Connect
        }
    }
}
