using System;
using BLL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 航班延误预测系统.command
{
    /// <summary>
    /// GetResult 的摘要说明
    /// </summary>
    public class GetResult : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ResultBLL bll = new ResultBLL();
            string flightno = context.Request["flightno"].ToString();
            DateTime date = DateTime.Parse(context.Request["time"].ToString());
            string depair = context.Request["depair"].ToString();
            string arrair = context.Request["arrair"].ToString();
            try
            {
              DataSet ds = bll.GetResult1(date, flightno, depair, arrair);
              string json = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0], new Newtonsoft.Json.Converters.DataTableConverter());
              context.Response.Write(json);
            }
            catch (Exception)
            {

                context.Response.Write("输入有误，请重新输入！");
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