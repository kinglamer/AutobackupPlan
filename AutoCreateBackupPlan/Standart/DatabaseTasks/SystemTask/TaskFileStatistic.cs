

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
            string sqlCommand = "declare @s varchar(max)" +
            " set @s = ''''" +
            " select @s = ''<table cellpadding=3 cellspacing=0 border=1>" +
            " <tr style=\"color:White;background-color:SteelBlue;font-weight:bold;\">" +

	         @"<td>Name</td>
	            <td>FILEID</td>
	            <td>FILE_SIZE_MB</td>
	            <td>SPACE_USED_MB</td>
	            <td>FREE_SPACE_MB</td>
	            <td>FILENAME</td>	
            </tr>'' +
            cast ((
            Select [Tag] = 1, [Parent] = 0, 
            [tr!1!td!element] = left(a.NAME,15),
            [tr!1!td!element] =  a.FILEID,
             [tr!1!td!element] = convert(decimal(12,2),round(a.size/128.000,2)),
             [tr!1!td!element] =  convert(decimal(12,2),round(fileproperty(a.name,''SpaceUsed'')/128.000,2)),
             [tr!1!td!element] =  convert(decimal(12,2),round((a.size-fileproperty(a.name,''SpaceUsed''))/128.000,2)) ,
             [tr!1!td!element] =  a.FILENAME
            From dbo.sysfiles a

            for xml explicit) as varchar(max))  + ''</table>''";
            sqlCommand += CommonCreator.AddEmailNotify(SystemTaskConstants.emailOperator, "Получение статистики файлов");

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
