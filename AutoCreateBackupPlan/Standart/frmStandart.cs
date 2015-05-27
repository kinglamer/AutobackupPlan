using System.Net;
using System.Net.Mail;
using AutoCreateBackupPlan.Standart.DatabaseMail;
using AutoCreateBackupPlan.Standart.DatabaseTasks;
using AutoCreateBackupPlan.Standart.DatabaseTasks.BackupSystemTasks;
using AutoCreateBackupPlan.Standart.DatabaseTasks.BackUpTasks;
using AutoCreateBackupPlan.Standart.DatabaseTasks.SystemTask;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using log4net;

namespace AutoCreateBackupPlan.Standart
{
    public partial class frmStandart : Form
    {
        private SqlConnection sqlConnection1 { get; set; }
        public frmStandart()
        {
            InitializeComponent();
          
        }
        private static readonly ILog log = LogManager.GetLogger(typeof(frmStandart));


        private void btSendEmail_Click(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Open)
            {
                frmEmail frm = new frmEmail();
                frm.ShowDialog();

                if (frm.EmailAdministrator)
                {

                    DataBaseOperations.TestSendingEmail(sqlConnection1, SystemTaskConstants.emailOperator);
                    MessageBox.Show("Сообщение отправлено на почту");
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmSetAddress frm = new frmSetAddress();
            frm.ShowDialog();

            if (frm.ConnectReady)
            {
                try
                {

                    sqlConnection1 = new SqlConnection(
                        string.Format(@"Data Source={0};User ID={1};Password={2};",
                                      ClassConstHelper.serverDelo, 
                                      frm.UserLogin, 
                                      frm.UserPass));

                    sqlConnection1.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ошибка при установки связи. Информация: " + ex.Message);
                }
            }
            else
            {
                Close();
            }
        }

        private void btCreateNotify_Click(object sender, EventArgs e)
        {

            if (sqlConnection1.State == ConnectionState.Open)
            {
                frmEmail frm = new frmEmail();
                frm.ShowDialog();

                if (frm.EmailAdministrator)
                {
                    TaskCheckDB task = new TaskCheckDB("BIT.DBCC.CHECKDB",
                                                       "Проверка БД Дело перед созданием полной копии базы",
                                                       ClassConstHelper.serverDelo,
                                                       "Проверка",
                                                       ClassConstHelper.deloDB);
                    task.Create(sqlConnection1, "TaskCheckDB");



                    TaskFileStatistic taskFile = new TaskFileStatistic("BIT.File.Statistics",
                                                                       "Информация о том, как распределено место в файловых группах базы Дело",
                                                                       ClassConstHelper.serverDelo,
                                                                       "Получение статистики",
                                                                       ClassConstHelper.deloDB);
                    taskFile.Create(sqlConnection1, "TaskFileStatistic");

                    rtbLog.AppendText("Настроены задачи дополнительного анализа БД\r\n");
                }
                else
                {
                    log.Debug("Не настроен почта администраора btCreateNotify_Click");
                }
            }
            
        }

        private void btInstall_Click(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Open)
            {

                frmBackupSetup frmBacksetup = new frmBackupSetup();
                frmBacksetup.ShowDialog();
                if (frmBacksetup.ConfigureTask)
                {

                    SQLHelper.ExecuteMyQuery(sqlConnection1, DatabaseConfig.ChangeRecoveryModel());

                    using (SqlDataReader reader = SQLHelper.GetDataReader(sqlConnection1,
                                                                       DatabaseConfig.CheckExistFullBackups()))
                    {
                        if (!reader.HasRows)
                            MessageBox.Show("Для указаной вами базы данных еще не выполнялось резервное копирование данных. \r\n" +
                                            "Необходимо выполнить его в ручную, чтобы начали формировать резервные копии журналов транзакций");
                    }


                    TaskBackUpTransaction task = new TaskBackUpTransaction("BIT.Backup.Transaction",
                    "Копия журналов транзакций базы данных Дело",
                     ClassConstHelper.serverDelo,
                     "Копия",
                     ClassConstHelper.deloDB, BackupFolders.pathTransaction);
                    task.Create(sqlConnection1, "TaskBackUpTransaction");

                    TaskBackupDifferent taskDiff = new TaskBackupDifferent("BIT.Backup.Different",
                        "Создание разностной копии базы данных Дело. С последующим удалением резервных копий журналов транзакций",
                          ClassConstHelper.serverDelo,
                         "Копия",
                         ClassConstHelper.deloDB, BackupFolders.pathDifferent);
                    taskDiff.Create(sqlConnection1, "TaskBackupDifferent");

                    TaskBackupFull taskFull = new TaskBackupFull("BIT.Backup.Full",
                        "Создание полной копии БД Дело. С последующим удалением журналов транзакций и разностных копий.",
                          ClassConstHelper.serverDelo,
                         "Копия",
                         ClassConstHelper.deloDB, BackupFolders.pathFull);
                    taskFull.Create(sqlConnection1, "TaskBackupFull");

                    rtbLog.AppendText("Настроен задачи резервного копирования БД Дело\r\n");


                  
                        TaskBackupMaster taskMaster = new TaskBackupMaster("BIT.Backup.master",
                          "Копия системной базы данных master",
                           ClassConstHelper.serverDelo,
                           "Копия",
                           "master", BackupFolders.pathMasterDB);
                        taskMaster.Create(sqlConnection1, "TaskBackupMaster");

                        TaskBackupMsdb taskMSDB = new TaskBackupMsdb("BIT.Backup.msdb",
                          "Копия системной базы данных msdb",
                           ClassConstHelper.serverDelo,
                           "Копия",
                           "msdb", BackupFolders.pathMSDB);
                        taskMSDB.Create(sqlConnection1, "TaskBackupMsdb");

                        rtbLog.AppendText("Все задачи резервного копирования системных баз настроены!\r\n");
                }

               
            }

         
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Open)
            {
                rtbLog.Text = string.Empty;
                string sqlDelete = @"USE [msdb];
                                    declare @jobId varchar(90)

                                    declare job_cursor cursor for
                                    select   
                                        j.job_id
                                    from dbo.sysjobs j
                                    where j.name like 'BIT.%'

                                    open job_cursor

                                    FETCH NEXT FROM job_cursor 
                                    INTO @jobId

                                    WHILE @@FETCH_STATUS = 0
                                    BEGIN
	                                    EXEC sp_delete_job @job_id=@jobId, @delete_unused_schedule=1

	                                    FETCH NEXT FROM job_cursor 
	                                    INTO @jobId
                                    end";
                SQLHelper.ExecuteMyQuery(sqlConnection1, sqlDelete);
                rtbLog.AppendText("Все созданные ранее задачи удалены\r\n");

                string deleteDatabaseEmailConfigs = string.Format(@"USE msdb ;
                EXECUTE sysmail_delete_profileaccount_sp @profile_name = '{2}', @account_name = '{0}';
                EXECUTE sysmail_delete_profile_sp @profile_name = '{2}' ;
                EXECUTE sysmail_delete_account_sp @account_name = '{0}';
                EXEC sp_delete_operator @name = '{1}';", 
                                          ClassConstHelper.accountName, 
                                          ClassConstHelper.emailOperatorName,
                                          ClassConstHelper.profileName);

                SQLHelper.ExecuteMyQuery(sqlConnection1, deleteDatabaseEmailConfigs);
                rtbLog.AppendText("Удалены настройки DatabaseMail\r\n");

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSetupDatabaseMail_Click(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Open)
            {

                frmProfile frm = new frmProfile();
                frm.ShowDialog();

                if (frm.CreateMail)
                {
                    DataBaseOperations.SetDatabaseMailConfig(sqlConnection1);


                    DataBaseOperations.CreateDatabaseMailAddon(sqlConnection1, frm.email_address, frm.mailserver_name,
                                                               frm.username, frm.password, frm.email_operator);

                    rtbLog.AppendText("Настроен модуль почты\r\n");

                    btCreateNotify.Enabled = true;
                    btSendEmail.Enabled = true;
                    btInstall.Enabled = true;

                    MessageBox.Show("Необходимо перезапустить вручную SQL Agent! Иначе не будут работать уведомления по почте");
                }
                else
                {
                    log.Debug("Не настроен DatabaseMail");
                    return;
                }
            }
        }
    }
}
