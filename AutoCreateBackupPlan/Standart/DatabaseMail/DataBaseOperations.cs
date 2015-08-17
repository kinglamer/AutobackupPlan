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
                string.Format(Resources.QueryStandart_ConfigProfile, Resources.Msg_Query_Profile);

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null && reader.HasRows)
                {
                    log.Debug(Resources.Msg_DBMail_ProfileExist);
                }
                else
                {
                    log.Debug(Resources.Msg_DBMail_DBMailProfileConfig);

                    int code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_CreateProfileDatabaseMail, Resources.Msg_Query_Profile));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);

                    log.Debug(Resources.Msg_DBMail_ActivateProfile);

                    code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_EnableEmailSQLAgent, Resources.Msg_Query_Profile));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
                }
                    
            }

            sqlCheck = string.Format(Resources.QueryStandart_ConfigAccount, Resources.Msg_Query_Account);

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null && reader.HasRows)
                {
                    log.Debug(Resources.Msg_DBMail_AccounExist);
                }
                else
                {

                    log.Debug(Resources.Msg_DBMail_AccountCreate);

                    int code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_CreateProfileDatabaseMail, mail, smtp, user, pass, Resources.Msg_Query_Account));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);

                    log.Debug(Resources.Msg_DBMail_AddAccountToDBmail);

                    code = SQLHelper.ExecuteMyQuery(connection,
                        string.Format(Resources.QueryStandart_AddAccountToProfileDatabaseMail, Resources.Msg_Query_Profile, Resources.Msg_Query_Account));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
                }
            }

            sqlCheck = string.Format(Resources.QueryStandart_ConfigOperator, Resources.Msg_Query_OperatorName);

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null &&  reader.HasRows)
                {
                    log.Debug(Resources.Msg_DBMail_OperatorExist);
                }
                else
                {
                    log.Debug(Resources.Msg_DBMail_OperatorCreate);

                    int code = SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_CreateOperator, emailOperator, Resources.Msg_Query_OperatorName));

                    log.Debug(Resources.Msg_DBMail_OperationExecuted + code);
                }
            }



        }

        /// <summary>
        /// Тест отправки email
        /// </summary>
        public static void TestSendingEmail(SqlConnection connection, string emailAddress)
        {
            SQLHelper.ExecuteMyQuery(connection, string.Format(Resources.QueryStandart_TestSendEmail, emailAddress, Resources.Msg_Query_Profile));
        }

   
    }
}
