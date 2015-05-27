using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return string.Format(@"USE [msdb];


            EXEC  msdb.dbo.sp_add_job @job_name='{0}', 
		    @enabled=1, 
		    @notify_level_eventlog=0, 
		    @notify_level_email=2, 
		    @notify_level_netsend=2, 
		    @notify_level_page=2, 
		    @delete_level=0, 
		    @description='{1}', 
		    @category_name='{3}', 
		    @owner_login_name='sa', 
		    @notify_email_operator_name='{4}';

            EXEC msdb.dbo.sp_add_jobserver @job_name='{0}', @server_name = '{2}';", 
                                                                                  nameJob, 
                                                                                  descript, 
                                                                                  serverName,
                                                                                  categoryNames[taskType],
                                                                                  ClassConstHelper.emailOperatorName);
        }

        public static string AddJobStep(int stepId, int onSuccess, int onFail,
            string nameJob, string stepName, string dbName, string sqlCommand)
        {
            
            return string.Format(@"USE [msdb];

            EXEC msdb.dbo.sp_add_jobstep @job_name='{0}', @step_name='{1}', 
		            @step_id={4}, 
		            @cmdexec_success_code=0, 
		            @on_success_action={5}, 
		            @on_fail_action={6}, 
		            @retry_attempts=0, 
		            @retry_interval=0, 
		            @os_run_priority=0, @subsystem='TSQL', 
		            @command='{3}',
                    @database_name='{2}', 
		            @flags=0;", nameJob, stepName, dbName, sqlCommand,stepId, onSuccess, onFail );
        }

        public static string AddEmailNotify(string email, string subject)
        {
            return string.Format(@" EXEC msdb.dbo.sp_send_dbmail
            @profile_name = ''{0}'',
              @recipients = ''{1}'',
              @subject = ''{2}'',
              @body = @s,
              @body_format = ''HTML''", ClassConstHelper.profileName, email, subject);
        }

        public static string UpdateJob(int levelEmail, string nameJob, string descript, CategorySqlTask taskType)
        {
            return string.Format(@"USE [msdb];

           EXEC msdb.dbo.sp_update_job @job_name='{0}', 
		        @enabled=1, 
		        @start_step_id=1, 
		        @notify_level_eventlog=0, 
		        @notify_level_email={4}, 
		        @notify_level_netsend=2, 
		        @notify_level_page=2, 
		        @delete_level=0, 
		        @description='{1}', 
		        @category_name='{2}', 
		        @owner_login_name='sa', 
		        @notify_email_operator_name='{3}', 
		        @notify_netsend_operator_name='', 
		        @notify_page_operator_name='';", nameJob, 
                                               descript, 
                                               categoryNames[taskType],
                                               ClassConstHelper.emailOperatorName, levelEmail);
        }

        public static string JobSchedule(string nameJob, int Interval, int subdayType, 
            int subdayInterval, int startTime, int endTime, string name, int freqType, int relativeInterval)
        {
            return string.Format(@"USE [msdb];
	
            EXEC msdb.dbo.sp_add_jobschedule @job_name='{0}', @name='{7}', 
		            @enabled=1, 
		            @freq_type={8}, 
		            @freq_interval={2}, 
		            @freq_subday_type={3}, 
		            @freq_subday_interval={4}, 
		            @freq_relative_interval={9}, 
		            @freq_recurrence_factor=1, 
		            @active_start_date={1}, 
		            @active_end_date=99991231, 
		            @active_start_time={5}, 
		            @active_end_time={6};", nameJob,
                                             DateTime.Now.ToString("yyyyMMdd"),
                                             Interval, 
                                             subdayType,
                                             subdayInterval,
                                             startTime,
                                             endTime, name, freqType, relativeInterval);
        }
    }
}
