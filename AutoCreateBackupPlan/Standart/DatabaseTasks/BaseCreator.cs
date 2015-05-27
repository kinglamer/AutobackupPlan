using System.Windows.Forms;
using log4net;
using System;
using System.Data.SqlClient;

namespace SaveMyDatabase.DatabaseTasks
{
    class BaseCreator : ICreatorTasks
    {
        public BaseCreator(string nameJob, string descript, string serverName, string stepName, string dbName)
        {
            this.nameJob = nameJob;
            this.descript = descript;
            this.serverName = serverName;
            this.stepName = stepName;
            this.dbName = dbName;
        }

        public string nameJob { get; set; }
        public string descript { get; set; }
        public string serverName { get; set; }
        public string stepName { get; set; }
        public string dbName { get; set; }

        
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseCreator));

        public void Create(SqlConnection connection, string nameOperation)
        {
            log.Debug("Стартует операция: " + nameOperation);
            string executedCommand = "";
            try
            {
                if (ExistJob(connection)) return;

                executedCommand = "AddJob";
                SQLHelper.ExecuteMyQuery(connection, AddJob());

                executedCommand = "AddJobStep";
                SQLHelper.ExecuteMyQuery(connection, AddJobStep());

                executedCommand = "UpdateJob";
                SQLHelper.ExecuteMyQuery(connection, UpdateJob());

                executedCommand = "JobSchedule";
                SQLHelper.ExecuteMyQuery(connection, JobSchedule());
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Ошибка на этапе выполнения команды: {0}\r\nСведения: {1}",
                    executedCommand,
                    ex.Message));
                MessageBox.Show("При выполнение возникла ошибка. См. файл логов");

            }
        }

        private bool ExistJob(SqlConnection connection)
        {
            string sqlCheckJob = "select * from msdb.dbo.sysjobs where name like '" + nameJob + "'";
            using (SqlDataReader reader = SQLHelper.GetDataReader(connection, sqlCheckJob))
            {

                if (reader != null && reader.HasRows)
                {
                    log.Debug("Задача " + nameJob + " уже создана в базе данных");
                  
                    return true;
                }
                
            }
            return false;
        }

        public virtual string AddJob()
        {
            return CommonCreator.AddJob(nameJob, descript, serverName, CategorySqlTask.DatabaseMaintenance);
        }

        public virtual string UpdateJob()
        {
            return CommonCreator.UpdateJob(2,nameJob, descript, CategorySqlTask.DatabaseMaintenance);
        }

        public virtual string AddJobStep()
        {
            throw new NotImplementedException();
        }

        public virtual string JobSchedule()
        {
            throw new NotImplementedException();
        }
    }
}
