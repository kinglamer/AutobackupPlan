using AutoCreateBackupPlan.Standart.DatabaseMail;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.SystemTask
{
    public partial class frmEmail : Form
    {

        private ErrorProvider errorProvider1 = new ErrorProvider();

        public bool EmailAdministrator { get; set; }
        private bool validMail;

        public frmEmail()
        {
            InitializeComponent();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            
            if (SystemTaskConstants.emailOperator.Length > 0)
            {
                tbEmail.Text = SystemTaskConstants.emailOperator;
                validMail = true;
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
                SystemTaskConstants.emailOperator = tbEmail.Text;

                EmailAdministrator = true;
                Close();
            }
            else
            {
                MessageBox.Show("Необходимо указать почту");
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
