using System;

namespace AutoCreateBackupPlan.Common
{
    [Serializable]
    public class UserEmailData
    {
        public UserEmailData(string adminEmail, string sendEmail, string smtpServer, string emailUser, string emailPassword, string operatorName)
        {
            AdminEmail = adminEmail;
            SendEmail = sendEmail;
            SmtpServer = smtpServer;
            EmailUser = emailUser;
            EmailPassword = emailPassword;
            OperatorName = operatorName;
        }

        public string AdminEmail { get; private set; }
        public string SendEmail { get; private set; }
        public string SmtpServer { get; private set; }
        public string EmailUser { get; private set; }
        public string EmailPassword { get; private set; }
        public string OperatorName { get; private set; }
    }
}