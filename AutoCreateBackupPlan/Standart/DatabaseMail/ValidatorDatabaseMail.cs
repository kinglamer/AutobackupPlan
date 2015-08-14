using System.Windows.Forms;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    class ValidatorDatabaseMail
    {
        public static bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the e-mail address string is not empty. 
            if (emailAddress.Length == 0)
            {
                errorMessage = Resources.Msg_ErrorEmail;
                return false;
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = Resources.Msg_ErrorEmailFormat;
            return false;
        }

        public static bool ValidSMTPAddress(string smtp, string email, out string errorMessage)
        {
            errorMessage = "";

            if (smtp.Length == 0)
            {
                errorMessage = Resources.Msg_ErrorSmtp;
                return false;
            }

            int index = email.IndexOf("@");
            if (index > -1)
            {
                string domen = email.Substring(index + 1);

                if (!smtp.Contains(domen))
                {
                    errorMessage = Resources.Msg_ErrorSmtpCompare;
                    return false;
                }
            }

            return true;
        }

        public static bool ValidSimpleString(string text, out string errorMessage)
        {
            errorMessage = Resources.Msg_ErrorFieldMustBeNotEmpty;

            if (text.Length == 0)
            {
                errorMessage = "";
                return false;
            }

            return true;
        }

        public static void AnalyValid(TextBox textBox, bool validVal, string errorMsg, ErrorProvider errorProvider)
        {
            if (!validVal)
            {
                textBox.Select(0, textBox.Text.Length);
                errorProvider.SetError(textBox, errorMsg);
            }
            else
            {
                errorProvider.SetError(textBox, "");
            }
        }

        public static void ValidatingTextBox(TextBox textBox,out bool validVal, ErrorProvider errorProvider)
        {
            string errorMsg;
            validVal = ValidSimpleString(textBox.Text, out errorMsg);

            AnalyValid(textBox, validVal, errorMsg, errorProvider);
        }
    }
}
