
using System.Data.SqlClient;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks
{
    interface ICreatorTasks
    {

       
          string AddJob();
          string AddJobStep();
          string UpdateJob();
          string JobSchedule();

    }
}
