using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Data;
using Newtonsoft.Json;

namespace 航班延误预测系统.command
{
    /// <summary>
    /// flightNo 的摘要说明
    /// </summary>
    public class flightNo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");
            flightNoBLL bll = new flightNoBLL();
            DataSet ds;
            if (context.Request["id"] == "1")
            {
                //DateTime date=DateTime.Parse("2015-11-3") ;
                String t = context.Request["date"].ToString();
                DateTime date = DateTime.Parse(context.Request["date"]);


                string d = context.Request["date"];
                //string date = context.Request["date"].ToString ();
                ds = bll.getFlightNo(date);
            }
            else if (context.Request["id"] == "2")
            {
                ds = bll.getdepAir();
            }
            else
            {
                ds = bll.getarrAir();
            }
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