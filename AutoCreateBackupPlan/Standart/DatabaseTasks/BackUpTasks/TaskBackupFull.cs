using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.BackUpTasks
{
    class TaskBackupFull : BaseCreator
    {
        public TaskBackupFull(string nameJob, string descript,
            string serverName, string stepName, 
            string dbName, string pathFolderBackup)
            : base(nameJob, descript, serverName, stepName, dbName)
        {
            BackupFolders.pathFull = pathFolderBackup;
        }


        public override string AddJobStep()
        {
            string sqlCommand = string.Format(Resources.QueryStandart_BaseBackupQuery,
                dbName, BackupFolders.pathFull, ClassConstHelper.full_name, Resources.QueryStandart_TimeStamp, TypeBackupObject.DATABASE, BackupParametres.NOFORMAT);

            string sqlCommand2 = string.Format(Resources.QueryStandart_DeleteOldBackup, BackupFolders.pathTransaction, Resources.QueryStandart_GetDate);

            string sqlCommand3 = string.Format(Resources.QueryStandart_DeleteOldBackup, BackupFolders.pathDifferent, Resources.QueryStandart_GetDate);

            string sqlCommand4 = string.Format(Resources.QueryStandart_DeleteOldBackup, BackupFolders.pathFull, Resources.QueryStandart_DateADD7);

            return string.Format("{0} {1} {2} {3}", 
                CommonCreator.AddJobStep(1, 3, 2, nameJob, stepName, dbName, sqlCommand),
                CommonCreator.AddJobStep(2, 3, 2, nameJob, Resources.Msg_Query_DeleteTransaction, dbName, sqlCommand2), 
                CommonCreator.AddJobStep(3, 3, 2, nameJob, Resources.Msg_Query_DeleteDiff, dbName, sqlCommand3),
                CommonCreator.AddJobStep(4, 1, 2, nameJob, Resources.Msg_Query_DeleteOldCopy, dbName, sqlCommand4));
        }

        public override string UpdateJob()
        {
            return CommonCreator.UpdateJob(3, nameJob, descript, CategorySqlTask.DatabaseMaintenance);
        }

        public override string JobSchedule()
        {
            return CommonCreator.JobSchedule(nameJob, 64, 1, 0, 180000, 235959, Resources.Msg_Query_Sheduler, 8, 0);
        }
    }
}
