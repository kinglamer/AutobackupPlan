
using System.Data.SqlClient;

namespace SaveMyDatabase.DatabaseTasks
{
    interface ICreatorTasks
    {

       
          string AddJob();
          string AddJobStep();
          string UpdateJob();
          string JobSchedule();

    }
}
