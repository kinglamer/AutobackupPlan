
namespace SaveMyDatabase.DatabaseTasks
{
    class BackupFolders
    {
        public static string pathMSDB;
        public static string pathMasterDB;
        public static string pathTransaction;
        public static string pathDifferent;
        public static string pathFull;

        static BackupFolders()
        {
            pathMSDB = string.Empty;
            pathMasterDB = string.Empty;
            pathTransaction = string.Empty;
            pathDifferent = string.Empty;
            pathFull = string.Empty;
        }
    }


}
