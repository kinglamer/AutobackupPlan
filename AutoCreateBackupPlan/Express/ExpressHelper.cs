using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Express
{
    static class ExpressHelper
    {
        public static string[] hours =
            {
                "18","19","20","21","22","23","00","01","02","03","04","05","06","07","08"
            };


        public static string[] min =
            {
                "00","01","02","03", "04","05","06","07","08","09","10"
                ,"11","12","13","14","15","16","17","18","19","20"
                ,"21","22","23","24","25","26","27","28","29","30"
                ,"31","32","33","34","35","36","37","38","39","40"
                ,"41","42","43","44","45","46","47","48","49","50"
                ,"51","52","53","54","55","56","57","58","59","60"
            };

        public static string GetSQLQuery(string tbPath, string tbDBName)
        {
            string pathBackup =  SetupPath(tbPath);

            return string.Format(Resources.QueryExpress_FullBackupExpress, tbDBName.ToUpper(), pathBackup);
        }

        public static bool AllfieldsNotEmpty(List<Control> controls)
        {
            bool returnVal = true;

            foreach (Control item in controls)
            {
                if (item.Text.Length == 0)
                {
                    returnVal = false;
                    break;
                }
            }

            return returnVal;
        }

        public static string GetBatText(string PathConfig, string tbServer, string tbUser, string tbPass)
        {
            return string.Format(Resources.BackupExpressBatCommand, tbServer, tbUser, tbPass, PathConfig);
        }

        public static string SetupPath(string userPath)
        {
            string retVal = string.Empty;
            if (!CheckPath(userPath))
            {
                MessageBox.Show(Resources.Msg_ErrorCheckExistFolders);
            }
            else
            {
                if (userPath.IndexOf(@"\", userPath.Length - 1) > 0)
                    retVal = userPath;
                else
                {
                    retVal = userPath + @"\";
                }
            }
            return retVal;
        }

        private static bool CheckPath(string pathFolder)
        {
            bool returnVal = true;

            try
            {
                if (pathFolder.Length > 210)
                {
                    MessageBox.Show(string.Format("{0} {1}", Resources.Msg_ErrorCreateFolder, pathFolder));
                    return false;
                }


                if (!Directory.Exists(pathFolder))
                {


                    DialogResult dialogResult = MessageBox.Show(string.Format(Resources.Msg_CatalotNotExistCreate, pathFolder),Resources.Msg_CatalogNotExist, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Directory.CreateDirectory(pathFolder);
                        MessageBox.Show(Resources.Msg_Create);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show(Resources.OperationCancel);
                        returnVal = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Msg_Error + ex.Message);
                returnVal = false;
            }

            return returnVal;
        }
    }
}
