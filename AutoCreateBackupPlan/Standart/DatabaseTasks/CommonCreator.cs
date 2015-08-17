using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks
{
    public enum CategorySqlTask
    {
        /// <summary>
        /// Обслуживание базы данных
        /// </summary>
        DatabaseMaintenance,

        /// <summary>
        /// Сборщик данных
        /// </summary>
        DataCollector
    }

    class CommonCreator
    {
        private static Dictionary<CategorySqlTask, string> categoryNames { get; set; }

        static CommonCreator() 
        {
            categoryNames = new Dictionary<CategorySqlTask, string>();
            categoryNames.Add(CategorySqlTask.DatabaseMaintenance, "Database Maintenance");
            categoryNames.Add(CategorySqlTask.DataCollector, "Data Collector");

        }

        public static string AddJob(string nameJob, string descript, string serverName, CategorySqlTask taskType)
        {
            return string.Format(Resources.QueryStandart_AddJob, 
                                                                                  nameJob, 
                                                                                  descript, 
                                                                                  serverName,
                                                                                  categoryNames[taskType],
                                                                                  Resources.Msg_Query_OperatorName);
        }

        public static string AddJobStep(int stepId, int onSuccess, int onFail,
            string nameJob, string stepName, string dbName, string sqlCommand)
        {
            
            return string.Format(Resources.QueryStandart_AddJobStep, nameJob, stepName, dbName, sqlCommand,stepId, onSuccess, onFail );
        }

        public static string AddEmailNotify(string email, string subject)
        {
            return string.Format(Resources.QueryStandart_AddEmailNotify, Resources.Msg_Query_Profile, email, subject);
        }

        public static string UpdateJob(int levelEmail, string nameJob, string descript, CategorySqlTask taskType)
        {
            return string.Format(Resources.QueryStandart_UpdateJob, nameJob, 
                                               descript, 
                                               categoryNames[taskType],
                                               Resources.Msg_Query_OperatorName, levelEmail);
        }

        public static string JobSchedule(string nameJob, int Interval, int subdayType, 
            int subdayInterval, int startTime, int endTime, string name, int freqType, int relativeInterval)
        {
            return string.Format(Resources.QueryStandart_JobSchedule, nameJob,
                                             DateTime.Now.ToString("yyyyMMdd"),
                                             Interval, 
                                             subdayType,
                                             subdayInterval,
                                             startTime,
                                             endTime, name, freqType, relativeInterval);
        }
    }
}
