using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.BackUpTasks
{
    class TaskBackupDifferent : BaseCreator
    {
        public TaskBackupDifferent(string nameJob, string descript,
            string serverName, string stepName, 
            string dbName, string pathFolderBackup)
            : base(nameJob, descript, serverName, stepName, dbName)
        {
            BackupFolders.pathDifferent = pathFolderBackup;
        }


        public override string AddJobStep()
        {
            string sqlCommand = string.Format(Resources.QueryStandart_BaseBackupQuery, 
                dbName, BackupFolders.pathDifferent, ClassConstHelper.diff_name,
                Resources.QueryStandart_TimeStamp, TypeBackupObject.DATABASE, BackupParametres.DIFFERENTIAL);


            string sqlCommand2 = string.Format(Resources.QueryStandart_DeleteOldBackup, BackupFolders.pathTransaction, Resources.QueryStandart_GetDate);

            return string.Format("{0} {1}", 
                CommonCreator.AddJobStep(1, 3, 2, nameJob, stepName, dbName, sqlCommand),
                CommonCreator.AddJobStep(2, 1, 2, nameJob, Resources.Msg_Query_DeleteTransaction, dbName, sqlCommand2));
        }



        public override string JobSchedule()
        {
            return CommonCreator.JobSchedule(nameJob, 63, 1, 0, 220000, 235959, Resources.Msg_Query_Sheduler, 8, 0);
        }
    }
}
