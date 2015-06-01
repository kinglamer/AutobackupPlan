using AutoCreateBackupPlan.Standart.DatabaseMail;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks
{
    public partial class frmBackupSetup : Form
    {
        FolderBrowserDialog dialog { get; set; }

        private ErrorProvider errorProvider1 = new ErrorProvider();

        public bool ConfigureTask { get; set; }
        private bool validMaster;
        private bool validTran;
        private bool validDiff;
        private bool validFull;
        private bool validMSDB;

        public frmBackupSetup()
        {
            InitializeComponent();

            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            dialog = new FolderBrowserDialog();
                
            dialog.Description = "Укажите путь до папки хранения копий";
            dialog.ShowNewFolderButton = true;
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            ConfigureTask = false;
            Close();
        }

        private void btPathFull_Click(object sender, EventArgs e)
        {
            tbFull.Text = GetPath();
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
                MessageBox.Show("Ошибка:" + exc.Message);
            }

            return string.Empty;
        }

        private void btPathDiff_Click(object sender, EventArgs e)
        {
            tbDiff.Text = GetPath();
        }

        private void btPathTran_Click(object sender, EventArgs e)
        {
            tbTran.Text = GetPath();
        }

        private void btPathMaster_Click(object sender, EventArgs e)
        {
            tbMaster.Text = GetPath();
        }

        private void btPathMSDB_Click(object sender, EventArgs e)
        {
            tbMSDB.Text = GetPath();
        }

        private void tbFull_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(sender as Control, 30);
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validFull, errorProvider1);
        }

        private void tbDiff_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(sender as Control, 30);
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validDiff, errorProvider1);
        }

        private void tbTran_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(sender as Control, 30);
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validTran, errorProvider1);
        }

        private void tbMaster_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(sender as Control, 30);
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validMaster, errorProvider1);
        }

        private void tbMSDB_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(sender as Control, 30);
            ValidatorDatabaseMail.ValidatingTextBox(sender as TextBox, out validMSDB, errorProvider1);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (validDiff && validFull && validMSDB && validMaster && validTran)
            {
               
                if (SetupPath(tbFull.Text,ref BackupFolders.pathFull)) return;

                if (SetupPath(tbDiff.Text, ref BackupFolders.pathDifferent)) return;


                if (SetupPath(tbTran.Text, ref BackupFolders.pathTransaction)) return;

                if (SetupPath(tbMaster.Text, ref BackupFolders.pathMasterDB)) return;

                if (SetupPath(tbMSDB.Text, ref BackupFolders.pathMSDB)) return;

                

                ConfigureTask = true;
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private bool SetupPath(string userPath,ref string programPath)
        {
            if (!CheckPath(userPath))
            {
                MessageBox.Show("Проблема при проверке наличия папок. Операция прервана");
                return true;
            }
            else
            {
                if (userPath.IndexOf(@"\", userPath.Length - 1) > 0)
                    programPath = userPath;
                else
                {
                    programPath = userPath + @"\";
                }
            }
            return false;
        }

        private bool CheckPath(string pathFolder)
        {
            bool returnVal = true;

            try
            {
                if (pathFolder.Length > 210)
                {
                    MessageBox.Show("Слишком большая длинна пути до папки сохранения. Измените путь: \r\n" + pathFolder);
                    return false;
                }


                if (!Directory.Exists(pathFolder))
                {
                    

                    DialogResult dialogResult = MessageBox.Show(
                            "Каталог " + pathFolder + " не существует. Вы хотите его создать?",
                            "Отсутствует каталог", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(pathFolder);
                            MessageBox.Show("Создал");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Операция отменена");
                            returnVal = false;
                        }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
                returnVal = false;
            }

            return returnVal;
        }
    }
}
