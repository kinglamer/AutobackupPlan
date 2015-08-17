using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AutoCreateBackupPlan.Common;
using AutoCreateBackupPlan.Properties;
using Microsoft.Win32.TaskScheduler;

namespace AutoCreateBackupPlan.Express
{
    public partial class frmExpress : Form
    {
        private List<Control> controlsText;
        private readonly string fileUserData = "udExpress";

        public frmExpress()
        { 

            InitializeComponent();
            dialog = new FolderBrowserDialog();

            cbHours.Items.AddRange(ExpressHelper.hours);
            cbMinutes.Items.AddRange(ExpressHelper.min);

            controlsText = new List<Control>();
            controlsText.Add(tbOwner);
            controlsText.Add(tbPass);
            controlsText.Add(tbPath);
            controlsText.Add(tbPath2);
            controlsText.Add(tbServer);
            controlsText.Add(tbUser);
            controlsText.Add(cbHours);
            controlsText.Add(cbMinutes);

            Loadvalues();
        }

        private void Loadvalues()
        {
            UserData ud = UserData.Load(fileUserData);

            if (ud != null)
            {
                tbOwner.Text = ud.DbName;
                tbPass.Text = ud.Pass;
                tbPath.Text = ud.Paths["path"];
                tbPath2.Text = ud.Paths["path2"];
                tbServer.Text = ud.Server;
                tbUser.Text = ud.User;
                cbHours.Text = ud.Hours;
                cbMinutes.Text = ud.Minutes;
            }
        }

        FolderBrowserDialog dialog { get; set; }
        private string PathConfig = string.Empty;
        private string pathBat = string.Empty;

        private void btGetPath_Click(object sender, EventArgs e)
        {
            tbPath.Text = GetPath();
        }
        private void btGetP2_Click(object sender, EventArgs e)
        {
            tbPath2.Text = GetPath();
        }

        private string GetPath()
        {
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(Resources.Msg_Error + exc.Message);
            }

            return string.Empty;
        }

        private void btInstall_Click(object sender, EventArgs e)
        {
            if (!ExpressHelper.AllfieldsNotEmpty(controlsText))
            {
                MessageBox.Show(Resources.Msg_ErrorFillAllFields);
                return;
            }

            SaveValues();

            if (CreateComponents())
            {
                CreateTask();
                MessageBox.Show(Resources.Msg_Ready);
            }
        }

        private void SaveValues()
        {
            Dictionary<string,string> paths = new Dictionary<string, string>();
            paths.Add("path", tbPath.Text);
            paths.Add("path2", tbPath2.Text);
            UserData ud = new UserData(tbOwner.Text, tbPass.Text, tbServer.Text, tbUser.Text,  paths);
            ud.SetStartTime(cbHours.Text, cbMinutes.Text);
            ud.Save(fileUserData);
        }


        private void CreateTask()
        {
            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Backup DB: " + tbOwner.Text;

                // Create a trigger that will fire the task at this time every other day

                Trigger tg = new DailyTrigger();
                tg.StartBoundary = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                     Convert.ToInt32(cbHours.Text),
                                                     Convert.ToInt32(cbMinutes.Text), 0);


  
                td.Triggers.Add(tg);
                
                td.Settings.ExecutionTimeLimit = new TimeSpan(0); //убираем флаг останавливтаь задачу через 3 дня
                td.Actions.Add(new ExecAction(pathBat, null, PathConfig));

                ts.RootFolder.RegisterTaskDefinition(@"BackUpDBExpress", td);

             
            }
        }
        private bool CreateComponents()
        {
           
            PathConfig = ExpressHelper.SetupPath(tbPath2.Text);

            pathBat = Path.Combine(PathConfig, @"backup_full.bat");
            string pathSql = Path.Combine(PathConfig, @"backup_full.sql");

            if (!File.Exists(pathBat) && !File.Exists(pathSql))
            {

                using (StreamWriter outfile = new StreamWriter(pathBat))
                {
                    outfile.Write(ExpressHelper.GetBatText(PathConfig, tbServer.Text, tbUser.Text, tbPass.Text));
                }

                using (StreamWriter outfile = new StreamWriter(pathSql))
                {
                    outfile.Write(ExpressHelper.GetSQLQuery(tbPath.Text, tbOwner.Text));
                }

                return true;
            }
            else
            {
                MessageBox.Show(string.Format(Resources.Msg_CatalogAlredyExist, PathConfig));
                return false;
            }
        }
        
       

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }
      
    }
}
