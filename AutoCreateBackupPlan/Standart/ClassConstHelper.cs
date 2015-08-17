using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoCreateBackupPlan.Properties;

namespace AutoCreateBackupPlan.Standart
{
    public enum TypeBackupObject
    {
        DATABASE, LOG
    }

    public enum BackupParametres
    {
        DIFFERENTIAL, NOFORMAT
    }

    public class ClassConstHelper
    {

        /// <summary>
        /// Имена создаваемых реземерных копий баз данных. Не стал выносить в ресурсы
        /// </summary>
        public static readonly string masterdb_name = "''MASTER_''";
        public static readonly string msdb_name = "''MSDB_''";
        public static readonly string diff_name = "''KING_DIF_''";
        public static readonly string full_name = "''KING_FULL_''";
        public static readonly string trab_name = "''KING_TRAN_''";
        
        public static string DB { get; set; }
        public static string serverSQL { get; set; }

        public static readonly string fileConfigsStandart = "dbStandart";

        public static string emailOperator { get; set; }

    }
}
