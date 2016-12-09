using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public  class loginBLL
    {
         loginDAL dal = new loginDAL();
         public string getadminPwd(string username)
         {
             return dal.getadminPwd(username);
         }
    }
}
