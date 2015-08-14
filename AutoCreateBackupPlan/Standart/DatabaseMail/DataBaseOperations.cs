using System;
using System.Data;
using System.Data.SqlClient;
using AutoCreateBackupPlan.Properties;
using log4net;

namespace AutoCreateBackupPlan.Standart.DatabaseMail
{
    class DataBaseOperations
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DataBaseOperations));
        /// <summary>
        /// Подготовка MS SQL Server к настройка Database Mail компонента
        /// </summary>
        public static void SetDatabaseMailConfig(SqlConnection connection)
        {
            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, Resources.QueryStandart_GetConfigsDatabaseMail))
            {
                if (reader != null && reader.HasRows)
                {
                    if (CheckReconfigDatabase(reader, "Database Mail XPs"))
                    {
                        log.Debug(Resources.Msg_DBMail_ConfigIsReady);
                        return;
                    }
                }
                else
                {
                    log.Debug(Resources.Msg_DBMail_ConfigProgress);
                }
            }

            int code = SQLHelper.ExecuteMyQuery(connection, Resources.QueryStandart_ConfigDatabaseMail);

            log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
          

            
        }

        /// <summary>
        /// Проверка наличия конфигурации
        /// </summary>
        private static bool CheckReconfigDatabase(SqlDataReader reader, string name)
        {
            foreach (IDataRecord item in reader)
            {
                if (item["name"].Equals(name))
                {
                    return Convert.ToInt32(item["config_value"]) == 1;
                }
            }

            return false;
        }

        /// <summary>
        /// Создание необходимых настроек
        /// </summary>
        /// <param name="connection"></param>
        public static void CreateDatabaseMailAddon(SqlConnection connection, string mail, string smtp, string user, string pass, string emailOperator)
        {
        

            string sqlCheck = 
                "EXECUTE msdb.dbo.sysmail_help_profile_sp @profile_name = '" + ClassConstHelper.profileName + "';";

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null && reader.HasRows)
                {
                    log.Debug(Resources.Msg_DBMail_ProfileExist);
                }
                else
                {
                    log.Debug(Resources.Msg_DBMail_DBMailProfileConfig);

                    int code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_CreateProfileDatabaseMail, ClassConstHelper.profileName));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);

                    log.Debug(Resources.Msg_DBMail_ActivateProfile);

                    code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_EnableEmailSQLAgent, ClassConstHelper.profileName));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
                }
                    
            }

           sqlCheck = 
                "EXECUTE msdb.dbo.sysmail_help_profileaccount_sp @account_name  = '" + ClassConstHelper.accountName + "';";

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null && reader.HasRows)
                {
                    log.Debug(Resources.Msg_DBMail_AccounExist);
                }
                else
                {

                    log.Debug(Resources.Msg_DBMail_AccountCreate);

                    int code =  SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_CreateProfileDatabaseMail, mail, smtp, user, pass, ClassConstHelper.accountName));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);

                    log.Debug(Resources.Msg_DBMail_AddAccountToDBmail);

                    code = SQLHelper.ExecuteMyQuery(connection, 
                        string.Format(Resources.QueryStandart_AddAccountToProfileDatabaseMail, ClassConstHelper.profileName, ClassConstHelper.accountName));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
                }
            }

             sqlCheck =
                "EXECUTE msdb.dbo.sp_help_operator @operator_name  = '" + ClassConstHelper.emailOperatorName + "';";

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null &&  reader.HasRows)
                {
                    log.Debug(Resources.Msg_DBMail_OperatorExist);
                }
                else
                {
                    log.Debug(Resources.Msg_DBMail_OperatorCreate);

                    int code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_CreateOperator, emailOperator, ClassConstHelper.emailOperatorName));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
                }
            }



        }

        /// <summary>
        /// Тест отправки email
        /// </summary>
        public static void TestSendingEmail(SqlConnection connection, string emailAddress)
        {
            SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.TestSendEmail, emailAddress,ClassConstHelper.profileName));
        }

   
    }
}
