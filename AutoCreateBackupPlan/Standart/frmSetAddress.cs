using AutoCreateBackupPlan.Common;
using AutoCreateBackupPlan.Properties;
using AutoCreateBackupPlan.Standart.DatabaseMail;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart
{
    public partial class frmSetAddress : Form
    {
        private UserData ud;
        public frmSetAddress()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            
            ud = UserData.Load(ClassConstHelper.fileConfigsStandart);
            if (ud != null)
            {
                tbOwner.Text = ud.DbName;
                tbPass.Text = ud.Pass;
                tbServer.Text = ud.Server;
                tbUser.Text = ud.User;
            }
        }

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
            ValidatorDatabaseMail.ValidatingTextBox(tbServer, out validServer, errorProvider1);
            ValidatorDatabaseMail.ValidatingTextBox(tbOwner, out validOwner, errorProvider1);
            ValidatorDatabaseMail.ValidatingTextBox(tbUser, out validUser, errorProvider1);
            ValidatorDatabaseMail.ValidatingTextBox(tbPass, out validPass, errorProvider1);

            if (validOwner && validPass && validServer && validUser)
            {
                UserLogin = tbUser.Text;
                UserPass = tbPass.Text;

                ClassConstHelper.DB = tbOwner.Text;
                ClassConstHelper.serverSQL = tbServer.Text;

                ud.SetDatabase(tbOwner.Text, tbPass.Text, tbServer.Text, tbUser.Text);
                ud.Save(ClassConstHelper.fileConfigsStandart);

                ConnectReady = true;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.Msg_ErrorValidFields);
            }
        }

    }
}
