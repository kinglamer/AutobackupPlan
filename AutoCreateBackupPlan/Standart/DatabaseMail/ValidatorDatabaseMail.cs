using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    class ValidatorDatabaseMail
    {
        public static bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the e-mail address string is not empty. 
            if (emailAddress.Length == 0)
            {
                errorMessage = "Требуется введенный e-mail адрес";
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

            errorMessage = "e-mail адрес должен иметь правильный формат.\n" +
                           "Например 'someone@example.com' ";
            return false;
        }

        public static bool ValidSMTPAddress(string smtp, string email, out string errorMessage)
        {
            errorMessage = "";

            if (smtp.Length == 0)
            {
                errorMessage = "Требуется введенный адрес smtp сервера";
                return false;
            }

            int index = email.IndexOf("@");
            if (index > -1)
            {
                string domen = email.Substring(index + 1);

                if (!smtp.Contains(domen))
                {
                    errorMessage = "Домен почтового ящика и smtp сервера не совпадает";
                    return false;
                }
            }

            return true;
        }

        public static bool ValidSimpleString(string text, out string errorMessage)
        {
            errorMessage = "";

            if (text.Length == 0)
            {
                errorMessage = "Поле не должно быть пустым";
                return false;
            }

            return true;
        }

        public static void AnalyValid(TextBox textBox, bool validVal, string errorMsg, ErrorProvider errorProvider)
        {
            if (!validVal)
            {
                // Cancel the event and select the text to be corrected by the user.
                //    e.Cancel = true;
                textBox.Select(0, textBox.Text.Length);

                // Set the ErrorProvider error with the text to display.  
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
