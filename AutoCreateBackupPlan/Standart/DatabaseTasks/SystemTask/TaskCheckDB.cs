
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.SystemTask
{
    class TaskCheckDB : BaseCreator
    {
        public TaskCheckDB(string nameJob, string descript, string serverName, string stepName, string dbName) :
            base(nameJob, descript, serverName, stepName, dbName)
        {
        }



        public override string AddJobStep()
        {

            string sqlSumCommand = string.Format("{0}{1}", 
                Resources.QueryStandart_Part1_CheckDB,
                string.Format(Resources.QueryStandart_Part2_CheckDB, Resources.Msg_Query_Profile, ClassConstHelper.emailOperator, Resources.Msg_Query_CheckDB));
       
  

            string sqlCommand = string.Format(Resources.QueryStandart_Part3_CheckDB, sqlSumCommand, dbName);

            return CommonCreator.AddJobStep(1, 1, 2, nameJob, stepName, dbName, sqlCommand);

        }



        public override string JobSchedule()
        {
            return CommonCreator.JobSchedule(nameJob, 64, 1, 0, 120000, 235959, "Расписание", 8, 0);
        }
    }
}
