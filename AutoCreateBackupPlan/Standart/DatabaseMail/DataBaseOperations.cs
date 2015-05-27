using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace SaveMyDatabase.DatabaseMail
{
    class DataBaseOperations
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DataBaseOperations));
        /// <summary>
        /// Подготовка MS SQL Server к настройка Database Mail компонента
        /// </summary>
        public static void SetDatabaseMailConfig(SqlConnection connection)
        {
            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, DatabaseMailQuerys.GetConfigs()))
            {
                if (reader != null && reader.HasRows)
                {
                    if (CheckReconfigDatabase(reader, "Database Mail XPs"))
                    {
                        log.Debug("Системная таблица уже настроена");
                        return;
                    }
                }
                else
                {
                    log.Debug("Конфигурируем Database Mail");
                }
            }

            int code = SQLHelper.ExecuteMyQuery(connection, DatabaseMailQuerys.ConfigDatabaseMail());

            log.Debug("Операция выполнена с кодом: " + code);
          

            
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
                    log.Debug("Профиль уже создан");
                }
                else
                {
                    log.Debug("Конфигурируем Database Mail Profile");

                    int code = SQLHelper.ExecuteMyQuery(connection, DatabaseMailQuerys.CreateProfileDatabaseMail());

                    log.Debug("Операция выполнена с кодом: " + code);

                    log.Debug("Активируем в SQL Agente профиль");

                    code = SQLHelper.ExecuteMyQuery(connection, DatabaseMailQuerys.EnableEmailSQLAgent());

                    log.Debug("Операция выполнена с кодом: " + code);
                }
                    
            }

           sqlCheck = 
                "EXECUTE msdb.dbo.sysmail_help_profileaccount_sp @account_name  = '" + ClassConstHelper.accountName + "';";

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null && reader.HasRows)
                {
                    log.Debug("Аккаунт уже создан");
                }
                else
                {

                    log.Debug("Создаем Database Mail Account");

                    int code =  SQLHelper.ExecuteMyQuery(connection,
                                             DatabaseMailQuerys.CreateAccountDatabaseMail(mail, smtp, user, pass));

                    log.Debug("Операция выполнена с кодом: " + code);

                    log.Debug("Добавляем Account Database Mail к Profile");

                    code =  SQLHelper.ExecuteMyQuery(connection, DatabaseMailQuerys.AddAccountToProfileDatabaseMail());

                    log.Debug("Операция выполнена с кодом: " + code);
                }
            }

             sqlCheck =
                "EXECUTE msdb.dbo.sp_help_operator @operator_name  = '" + ClassConstHelper.emailOperatorName + "';";

            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheck))
            {
                if (reader != null &&  reader.HasRows)
                {
                    log.Debug("Оператор уже создан");
                }
                else
                {
                    log.Debug("Создаем Database Mail Operator");

                    int code = SQLHelper.ExecuteMyQuery(connection, DatabaseMailQuerys.CreateOperator(emailOperator));

                    log.Debug("Операция выполнена с кодом: " + code);
                }
            }



        }

        /// <summary>
        /// Тест отправки email
        /// </summary>
        public static void TestSendingEmail(SqlConnection connection, string emailAddress)
        {
            SQLHelper.ExecuteMyQuery(connection, DatabaseMailQuerys.TestSendEmail(emailAddress));
        }

   
    }
}
