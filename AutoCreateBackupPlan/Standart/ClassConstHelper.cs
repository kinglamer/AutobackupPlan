using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCreateBackupPlan.Standart
{
    public class ClassConstHelper
    {
       

        public static readonly string emailOperatorName = "King.Operator";
        public static readonly string profileName = "King.Profile";
        public static readonly string accountName = "King.Account";


        /// <summary>
        /// У каждого созданного файла бэкапа, будет ставиться временная метка, когда он был создан, с точностью до секунд
        /// </summary>
        public static readonly string formatTimeStampFiles = "REPLACE(REPLACE(convert(varchar,GETDATE(), 126),'':'',''_'') ,''.'',''_'')";

        /// <summary>
        /// Имена создаваемых реземерных копий баз данных 
        /// </summary>
        public static readonly string masterdb_name = "''MASTER_''";
        public static readonly string msdb_name = "''MSDB_''";
        public static readonly string diff_name = "''KING_DIF_''";
        public static readonly string full_name = "''KING_FULL_''";
        public static readonly string trab_name = "''KING_TRAN_''";
        
        public static string DB { get; set; }
        public static string serverSQL { get; set; }

        public static readonly string fileConfigsStandart = "dbStandart";


    }
}
