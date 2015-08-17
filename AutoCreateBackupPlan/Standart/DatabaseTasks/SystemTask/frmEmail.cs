using AutoCreateBackupPlan.Common;
using AutoCreateBackupPlan.Properties;
using AutoCreateBackupPlan.Standart.DatabaseMail;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.SystemTask
{
    public partial class frmEmail : Form
    {

        private ErrorProvider errorProvider1 = new ErrorProvider();
           
        private UserData ud;
        public bool EmailAdministrator { get; set; }
        private bool validMail;

        public frmEmail()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            
            
            ud = UserData.Load(ClassConstHelper.fileConfigsStandart);
            if (ud.userEmailData != null)
            {
                tbEmail.Text = ud.userEmailData.AdminEmail;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmailAdministrator = false;
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (validMail)
            {
                ClassConstHelper.emailOperator = tbEmail.Text;


                ud.SetEmailData(new UserEmailData(tbEmail.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
                ud.Save(ClassConstHelper.fileConfigsStandart);

                EmailAdministrator = true;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.Msg_RequiredEmial);
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;

            validMail = ValidatorDatabaseMail.ValidEmailAddress(tbEmail.Text, out errorMsg);

            ValidatorDatabaseMail.AnalyValid(tbEmail, validMail, errorMsg, errorProvider1);
        }
    }
}
