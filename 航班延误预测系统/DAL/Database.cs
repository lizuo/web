using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public sealed class Database : IDisposable
    {
        private static int listening = 0;

        public static int Listening
        {
            get { return Database.listening; }
        }
        SqlConnection con;
        SqlCommand cmd;
        public Database()
        {
            con = new SqlConnection("Data Source=.;Persist Security Info=True;User ID=sa;Initial Catalog=hbms;pwd=hbms");
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            listening++;
        }

        public int ExecSql(string sql)
        {
            cmd.CommandText = sql;
            int r = cmd.ExecuteNonQuery();
            return r;
        }

        public object ExecScalar(string sql)
        {
            cmd.CommandText = sql;
            object obj = cmd.ExecuteScalar();
            return obj;
        }

        public SqlDataReader GetDataReader(string sql)
        {
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }

        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void UpdateDataSet(string sql, DataSet ds)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da);

            da.UpdateCommand = cmdb.GetUpdateCommand();
            da.DeleteCommand = cmdb.GetDeleteCommand();
            da.InsertCommand = cmdb.GetInsertCommand();
            da.Update(ds);
        }

        public void CopyToDataBase(DataTable source, string name)
        {
            SqlTransaction tran = null;//声明一个事务对象  
            //try
            //{
            using (tran = con.BeginTransaction())
            {
                using (SqlBulkCopy copy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, tran))
                {
                    copy.DestinationTableName = name;  //指定服务器上目标表的名称  
                    //DataTable dd = CSV_Insert(Filepath);
                    copy.WriteToServer(source);  //执行把DataTable中的数据写入DB  
                    tran.Commit();                                      //提交事务  
                    //return true;                                        //返回True 执行成功！  
                }
            }
            // }
            //catch (Exception ex)
            //{
            //    if (null != tran)
            //        tran.Rollback();
            //    //LogHelper.Add(ex);  
            //    return false;//返回False 执行失败！  
            //}

        }


        public void Dispose()
        {
            con.Dispose();
            cmd.Dispose();
            listening--;
        }
    }

}
