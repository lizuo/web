using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using BLL;

namespace 航班延误预测系统.command
{
    /// <summary>
    /// getdepAir 的摘要说明
    /// </summary>
    public class getdepAir : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            flightNoBLL bll = new flightNoBLL();
            DataSet ds = bll.getdepAir();
            string result = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0], new Newtonsoft.Json.Converters.DataTableConverter());
            context.Response.Write(result);
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