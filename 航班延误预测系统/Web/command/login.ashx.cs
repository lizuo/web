using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;


namespace 航班延误预测系统.command
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string s = "";
       
            context.Response.ContentType = "text/plain";
           // context.Response.Write("Hello World");'
            string username = context.Request.Form["txtn"].ToString();
            string userPwd = context.Request["txtp"].ToString();
            loginBLL bll = new loginBLL();
            if (userPwd == bll.getadminPwd(username))
            {
                context.Response.Redirect("../default.aspx");
            }
            else
            {
                context.Response.Redirect("../login.aspx");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}