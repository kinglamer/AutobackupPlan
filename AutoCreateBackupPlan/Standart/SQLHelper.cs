using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using log4net;

namespace AutoCreateBackupPlan.Standart
{
    class SQLHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SQLHelper));

        public static SqlDataReader GetDataReader(SqlConnection connection, string query)
        {
            try
            {


                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }

            return null;
        }

        public static int ExecuteMyQuery(SqlConnection connection, string query)
        {
            try
            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;


                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }

            return 0;
        }





        public static int ExecuteMySP(SqlConnection connection, Dictionary<string, string> dataVal, string spName)
        {
            //Dictionary<string,string> parara = new Dictionary<string, string>();




            //parara.Add("@configname", "show advanced");
            //parara.Add("@configvalue", "1");
            //int i = ExecuteMySP(sqlConnection1, parara, "sp_CONFIGURE");

            // MessageBox.Show(i.ToString());
            try
            {



                SqlCommand cmd = new SqlCommand();
                SqlDataReader rdr = null;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;

                foreach (var item in dataVal)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }


                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

            }

            return 0;
            // return cmd.ExecuteNonQuery();
        }
    }
}
