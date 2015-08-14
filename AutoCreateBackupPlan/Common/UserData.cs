using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AutoCreateBackupPlan.Common
{
    [Serializable]
    public class UserData
    {
         public UserEmailData userEmailData { get; private set; }

         public string DbName { get; private set; }
         public string Pass { get; private set; }
      
         public Dictionary<string, string> Paths { get; private set; }
      
         public string Server { get; private set; }
         public string User { get; private set; }
         public string Hours { get; private set; }
         public string Minutes { get; private set; }



         public UserData(string dbName, string pass, string server, string user,  Dictionary<string, string> paths = null)
        {
            DbName = dbName;
            Pass = pass;
            Paths = paths;
            Server = server;
            User = user;
          
           
        }


         public void SetDatabase(string dbName, string pass, string server, string user)
         {
             DbName = dbName;
             Pass = pass;
             Server = server;
             User = user;
         }


        public void SetEmailData(UserEmailData _userEmailData)
        {
            userEmailData = _userEmailData;
        }

        public void SetStartTime(string hours, string minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public void SetPaths(Dictionary<string, string> paths)
        {
            Paths = paths;
        }


        public void Save(string filename)
        {
            using (var file = File.Open(filename, FileMode.Create, FileAccess.Write))
                new BinaryFormatter().Serialize(file, this);
        }

        public static UserData Load(string filename)
        {
            if (File.Exists(filename))
            {
                using (var file = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    return new BinaryFormatter().Deserialize(file) as UserData;
                }
            }
            
            return null;
        }
    }
}
