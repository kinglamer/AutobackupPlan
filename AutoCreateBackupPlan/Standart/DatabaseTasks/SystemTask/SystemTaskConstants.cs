using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCreateBackupPlan.Standart.DatabaseTasks.SystemTask
{
    class SystemTaskConstants
    {
        public static string emailOperator { get; set; }

        static SystemTaskConstants()
        {
            emailOperator = string.Empty;
        }
    }
}
