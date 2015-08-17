using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.BackupSystemTasks
{
    class TaskBackupMaster : BaseCreator
    {
        public TaskBackupMaster(string nameJob, string descript,
            string serverName, string stepName, 
            string dbName, string pathFolderBackup)
            : base(nameJob, descript, serverName, stepName, dbName)
        {
            BackupFolders.pathMasterDB = pathFolderBackup;
        }


        public override string AddJobStep()
        {
            string sqlCommand = string.Format(Resources.QueryStandart_BaseBackupQuery, 
                dbName, 
                BackupFolders.pathMasterDB, 
                ClassConstHelper.masterdb_name,
                Resources.QueryStandart_TimeStamp, TypeBackupObject.DATABASE, BackupParametres.NOFORMAT);


            string sqlCommand2 = string.Format(Resources.QueryStandart_DeleteOldBackup, BackupFolders.pathMasterDB, Resources.QueryStandart_DateADD7);

            return string.Format("{0} {1}", 
                CommonCreator.AddJobStep(1, 3, 2, nameJob, stepName, dbName, sqlCommand), 
                CommonCreator.AddJobStep(2, 1, 2, nameJob, Resources.Msg_Query_DeleteOldCopy, dbName, sqlCommand2));
        }



        public override string JobSchedule()
        {
            return CommonCreator.JobSchedule(nameJob, 1, 1, 0, 120000, 235959, Resources.Msg_Query_Sheduler, 8, 0);
        }
    }
}
