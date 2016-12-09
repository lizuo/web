using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public  class loginDAL
    {
       Database db = new Database();
       public string getadminPwd(string username)
       {
           string sql = "select * from admin where username='" + username + "'";
           SqlDataReader dr = db.GetDataReader(sql);
           if (dr.Read())
           {
               return dr[2].ToString().Trim();
           }
           else
           {
               return null;
           }
       }
    }
}
