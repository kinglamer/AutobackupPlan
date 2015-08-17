

using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.SystemTask
{
    class TaskFileStatistic : BaseCreator
    {
        public TaskFileStatistic(string nameJob, string descript, string serverName, string stepName, string dbName) 
            : base(nameJob, descript, serverName, stepName, dbName)
        {
        }

        public override string AddJob()
        {
            return CommonCreator.AddJob(nameJob, descript, serverName, CategorySqlTask.DataCollector);
        }

        public override string AddJobStep()
        {
            string sqlCommand = Resources.QueryStandart_GetFileStatistic;

            sqlCommand += CommonCreator.AddEmailNotify(ClassConstHelper.emailOperator, Resources.Msg_Query_GetFileStat);

            return CommonCreator.AddJobStep(1, 1, 2, nameJob, stepName, dbName, sqlCommand);
        }

        public override string UpdateJob()
        {
            return CommonCreator.UpdateJob(2,nameJob, descript, CategorySqlTask.DataCollector);
        }

        public override string JobSchedule()
        {
            return CommonCreator.JobSchedule(nameJob, 62, 8, 4, 80000, 200000, "Расписание", 8, 0);
        }
    }
}
