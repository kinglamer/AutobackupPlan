using System.Net;
using System.Net.Mail;
using AutoCreateBackupPlan.Properties;
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
                                      ClassConstHelper.serverSQL, 
                                      frm.UserLogin, 
                                      frm.UserPass));

                    sqlConnection1.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    frmMain_Load(this, e);
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
                    TaskCheckDB task = new TaskCheckDB(Resources.Msg_Query_Part1_TaskCheckDB,
                                                       Resources.Msg_Query_Part2_TaskCheckDB,
                                                       ClassConstHelper.serverSQL,
                                                       Resources.Msg_Query_Part3_TaskCheckDB,
                                                       ClassConstHelper.DB);
                    task.Create(sqlConnection1, "TaskCheckDB");



                    TaskFileStatistic taskFile = new TaskFileStatistic(Resources.Msg_Query_Part1_Staticstic,
                                                                       Resources.Msg_Query_Part2_Staticstic,
                                                                       ClassConstHelper.serverSQL,
                                                                       Resources.Msg_Query_Part3_Staticstic,
                                                                       ClassConstHelper.DB);
                    taskFile.Create(sqlConnection1, "TaskFileStatistic");

                    rtbLog.AppendText(Resources.Msg_ReadyAddionalTask);
                }
                else
                {
                    log.Debug(Resources.Msg_NotExistEmailAdmin);
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

                    SQLHelper.ExecuteMyQuery(sqlConnection1, string.Format(Resources.QueryStandart_ChangeRecoveryModel, ClassConstHelper.DB));

                    using (SqlDataReader reader = SQLHelper.GetDataReader(sqlConnection1,
                                                                       string.Format(Resources.QueryStandart_CheckExistBackup, ClassConstHelper.DB)))
                    {
                        if (!reader.HasRows)
                            MessageBox.Show(Resources.Msg_NeedManualBackup);
                    }


                    TaskBackUpTransaction task = new TaskBackUpTransaction(Resources.Msg_Query_Part1_Transaction,
                    Resources.Msg_Query_Part2_Transaction,
                     ClassConstHelper.serverSQL,
                     Resources.Msg_Query_Copy,
                     ClassConstHelper.DB, BackupFolders.pathTransaction);
                    task.Create(sqlConnection1, "TaskBackUpTransaction");

                    TaskBackupDifferent taskDiff = new TaskBackupDifferent(Resources.Msg_Query_Part1_Diff,
                        Resources.Msg_Query_Part2_Diff,
                         ClassConstHelper.serverSQL,
                         Resources.Msg_Query_Copy,
                         ClassConstHelper.DB, BackupFolders.pathDifferent);
                    taskDiff.Create(sqlConnection1, "TaskBackupDifferent");

                    TaskBackupFull taskFull = new TaskBackupFull(Resources.Msg_Query_Part1_Full,
                        Resources.Msg_Query_Part2_Full,
                          ClassConstHelper.serverSQL,
                         Resources.Msg_Query_Copy,
                         ClassConstHelper.DB, BackupFolders.pathFull);
                    taskFull.Create(sqlConnection1, "TaskBackupFull");

                    rtbLog.AppendText(Resources.Msg_JobBackupReady);



                    TaskBackupMaster taskMaster = new TaskBackupMaster(Resources.Msg_Query_Part1_Master,
                          Resources.Msg_Query_Part2_Master,
                           ClassConstHelper.serverSQL,
                           Resources.Msg_Query_Copy,
                           "master", BackupFolders.pathMasterDB);
                        taskMaster.Create(sqlConnection1, "TaskBackupMaster");

                        TaskBackupMsdb taskMSDB = new TaskBackupMsdb(Resources.Msg_Query_Part1_MSDB,
                          Resources.Msg_Query_Part2_MSDB,
                           ClassConstHelper.serverSQL,
                           Resources.Msg_Query_Copy,
                           "msdb", BackupFolders.pathMSDB);
                        taskMSDB.Create(sqlConnection1, "TaskBackupMsdb");

                        rtbLog.AppendText(Resources.Msg_BackupSystemDBReady);
                }

               
            }

         
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Open)
            {
                rtbLog.Text = string.Empty;
                string sqlDelete = Resources.QueryStandart_DeleteJobs;
                SQLHelper.ExecuteMyQuery(sqlConnection1, sqlDelete);
                rtbLog.AppendText(Resources.Msg_DeletedJobs);

                string deleteDatabaseEmailConfigs = string.Format(Resources.QueryStandart_DeleteProfilesDBMail,
                                          Resources.Msg_Query_Account,
                                          Resources.Msg_Query_OperatorName,
                                          Resources.Msg_Query_Profile);

                SQLHelper.ExecuteMyQuery(sqlConnection1, deleteDatabaseEmailConfigs);
                rtbLog.AppendText(Resources.Msg_Delete_ConfigDBMail);

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

                    rtbLog.AppendText(Resources.Msg_ConfigDBMail);

                    btCreateNotify.Enabled = true;
                    //btSendEmail.Enabled = true; //TODO: сделать модуль, который проверит все основные моменты
                    btInstall.Enabled = true;

                    MessageBox.Show(Resources.Msg_NeedRebootAgent);
                }
                else
                {
                    log.Debug(Resources.Msg_NotConfiguretedDBMail);
                }
            }
        }
    }
}
