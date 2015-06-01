
namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    internal class DatabaseMailQuerys
    {
     
    

        public static string ConfigDatabaseMail()
        {
            return @"USE master;
                exec sp_CONFIGURE 'show advanced', 1;                
                RECONFIGURE;                
                exec sp_CONFIGURE 'Database Mail XPs', 1;                
                RECONFIGURE;";
        }

        public static string GetConfigs()
        {
            return "RECONFIGURE;EXEC sp_configure;";
        }

        public static string CreateProfileDatabaseMail()
        {
            return string.Format(@"EXECUTE msdb.dbo.sysmail_add_profile_sp
                   @profile_name = '{0}',
                   @description = 'Профиль для уведомления о событиях связанных с базой данных';",
                                                                                            ClassConstHelper.profileName);
        }

        public static string CreateAccountDatabaseMail(string mail, string smtp, string user, string pass)
        {

            return string.Format(@"EXECUTE
            msdb.dbo.sysmail_add_account_sp
                @account_name = '{4}',
                @description = 'Аккаунт для отправки email сообщений',
                @email_address = '{0}',
                @display_name = 'King.Отправка уведомлений',
                @mailserver_name = '{1}',
                @username = '{2}',
                @password = '{3}';", mail, smtp, user, pass, ClassConstHelper.accountName);
        }

        public static string AddAccountToProfileDatabaseMail()
        {
            return string.Format(@"EXECUTE
            msdb.dbo.sysmail_add_profileaccount_sp
                @profile_name = '{0}',
                @account_name = '{1}',
                @sequence_number = 1;", ClassConstHelper.profileName,
                                      ClassConstHelper.accountName);
        }

        public static string CreateOperator(string emailAddress)
        {
            return string.Format(@"USE msdb;        
                                    EXEC msdb.dbo.sp_add_operator @name='{1}', 
		                            @enabled=1, 
		                            @pager_days=0, 
		                            @email_address='{0}'", emailAddress, ClassConstHelper.emailOperatorName);


        }

        public static string EnableEmailSQLAgent()
        {
            return string.Format(@"USE msdb;
            EXEC master.dbo.xp_instance_regwrite 
            'HKEY_LOCAL_MACHINE',
            'SOFTWARE\Microsoft\MSSQLServer\SQLServerAgent', 
            'DatabaseMailProfile', 
            'REG_SZ', '{0}'", ClassConstHelper.profileName);
        }



        public static string TestSendEmail(string emailAddress)
        {
            return string.Format(@" USE msdb; 
            
                EXECUTE sp_send_dbmail @profile_name = '{1}',
                           @recipients = '{0}',
                           @subject = 'Test message',
                           @body = 'Тестовое сообщение с MS SQL Server отправлено успешно';", emailAddress, 
                                                                                            ClassConstHelper.profileName);
        }


        
    }
}
