using System;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.BackUpTasks
{
    class TaskBackUpTransaction : BaseCreator
    {
      

        public TaskBackUpTransaction(string nameJob, string descript,
            string serverName, string stepName, 
            string dbName, string pathFolderBackup)
            : base(nameJob, descript, serverName, stepName, dbName)
        {
            BackupFolders.pathTransaction = pathFolderBackup;
        }
        


        public override string AddJobStep()
        {
            string sqlCommand = string.Format(Resources.QueryStandart_BaseBackupQuery, dbName,
                BackupFolders.pathTransaction, ClassConstHelper.trab_name, Resources.QueryStandart_TimeStamp, TypeBackupObject.LOG, BackupParametres.NOFORMAT);

            string sqlCommand2 = string.Format(Resources.QueryStandart_ShrinkTransaction, dbName);

            return string.Format("{0} {1}", 
                CommonCreator.AddJobStep(1, 3, 2, nameJob, stepName, dbName, sqlCommand), 
                CommonCreator.AddJobStep(2, 1, 2, nameJob, Resources.Msg_Query_ShrinkLogs, dbName, sqlCommand2)); ;
        }

 

        public override string JobSchedule()
        {
            return string.Format("{0} {1}", 
                CommonCreator.JobSchedule(nameJob, 62, 8, 1, 80000, 210000, string.Format("{0}(будни)", Resources.Msg_Query_Sheduler), 8, 0), 
                CommonCreator.JobSchedule(nameJob, 65, 8, 1, 80000, 180000, string.Format("{0}(выходные)", Resources.Msg_Query_Sheduler), 8, 0));

        }

      
    }
}
