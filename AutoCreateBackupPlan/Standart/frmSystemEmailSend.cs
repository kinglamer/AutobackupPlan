using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace SaveMyDatabase
{
    public partial class frmSystemEmailSend : Form
    {
        public frmSystemEmailSend()
        {
            InitializeComponent();
            
        }

        private  void SendMail(string smtpServer, string from, string port, string password,
                                   string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = Convert.ToInt32(port);
                
                //client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                  client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
                MessageBox.Show("Отправил");
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
            
        }


        private void btSend_Click(object sender, EventArgs e)
        {
            SendMail(tbSmtpServer.Text, tbLogin.Text,tbSMTPPort.Text, tbPass.Text, tbToWho.Text, "Тест почты", "Все отправляется хорошо");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMail("mail.biz-it.ru", "budaev@biz-it.ru","25", "Ghfrnbr1", "budaev@biz-it.ru", "La la", "Bla bla");
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
