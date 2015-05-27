
namespace SaveMyDatabase.DatabaseTasks.SystemTask
{
    class TaskCheckDB : BaseCreator
    {
        public TaskCheckDB(string nameJob, string descript, string serverName, string stepName, string dbName) :
            base(nameJob, descript, serverName, stepName, dbName)
        {
        }



        public override string AddJobStep()
        {

            string sqlSumCommand = "''declare @s varchar(max)" +

                                   " select @s =  ''''<table cellpadding=3 cellspacing=0 border=1>" +
                                   " <tr style=\"color:White;background-color:SteelBlue;font-weight:bold;\">" +

                                   @" <td>DBName</td>
                                   <td>Output</td>
                                   <td>MessageText</td>
                                   </tr>''''+
                                   cast ((SELECT [Tag] = 1, [Parent] = 0,  
                                   [tr!1!td!element] = DB_NAME(DbId), '' + 
                                   ''[tr!1!td!element] = CASE WHEN MessageText LIKE ''''%0 allocation errors and 0 consistency errors%'''' THEN 0 ELSE 1 END,
                                   [tr!1!td!element] = MessageText 
                                   FROM #DBCC_OUTPUT 
                                   for xml explicit) as varchar(max))  + ''''</table>''''" +

              string.Format(@" EXEC msdb.dbo.sp_send_dbmail
            @profile_name = ''''{0}'''',
              @recipients = ''''{1}'''',
              @subject = ''''{2}'''',
              @body = @s,
              @body_format = ''''HTML'''';''", ClassConstHelper.profileName, SystemTaskConstants.emailOperator, "Выполнение DBCC CHECKDB");
            //использую не стандартную функцию, т.к. в данном случае это запрос в тексте, и требовалось больше амперсантов
        //    sqlSumCommand += CommonCreator.AddEmailNotify(, ) + ""; 

            string sqlCommand = string.Format(@"declare @dbName varchar(50),
	@PHYSICAL_ONLY bit = 0
	
set @dbName = ''{1}''

IF OBJECT_ID(''tempdb..#DBCC_OUTPUT'') IS NOT NULL
		DROP TABLE #DBCC_OUTPUT

	CREATE TABLE #DBCC_OUTPUT(
		Error int NOT NULL,
		[Level] int NOT NULL,
		State int NOT NULL,
		MessageText nvarchar(256) NOT NULL,
		RepairLevel int NULL,
		Status int NOT NULL,
		DbId int NOT NULL,
		ObjectId int NOT NULL,
		IndexId int NOT NULL,
		PartitionId int NOT NULL,
		AllocUnitId int NOT NULL,
		[File] int NOT NULL,
		Page int NOT NULL,
		Slot int NOT NULL,
		RefFile int NOT NULL,
		RefPage int NOT NULL,
		RefSlot int NOT NULL,
		Allocation int NOT NULL
	)

	DECLARE c_databases CURSOR LOCAL FAST_FORWARD
	FOR
	SELECT Name
	FROM master.sys.databases
	WHERE Name = ISNULL(@dbName, Name)

	OPEN c_databases
	
	FETCH NEXT FROM c_databases INTO @dbName

	WHILE @@FETCH_STATUS = 0
	BEGIN

		DECLARE @sql nvarchar(4000)
		SET @sql = ''DBCC CHECKDB(''+ @dbName +'') WITH TABLERESULTS, ALL_ERRORMSGS''
		
		IF @PHYSICAL_ONLY = 1 
			SET @sql = @sql + '', PHYSICAL_ONLY ''


		INSERT INTO #DBCC_OUTPUT
		EXEC(@sql)

		FETCH NEXT FROM c_databases INTO @dbName
	END
	
	CLOSE c_databases
	DEALLOCATE c_databases

	IF NOT EXISTS (
		SELECT 1 FROM #DBCC_OUTPUT 
	)
	BEGIN 
		RAISERROR(''No database matches the name specified.'',10,1)
	END 

    SET @sql = {0}

    EXEC(@sql);", sqlSumCommand, dbName);



          //

            return CommonCreator.AddJobStep(1, 1, 2, nameJob, stepName, dbName, sqlCommand);

        }



        public override string JobSchedule()
        {
            return CommonCreator.JobSchedule(nameJob, 64, 1, 0, 120000, 235959, "Расписание", 8, 0);
        }
    }
}
