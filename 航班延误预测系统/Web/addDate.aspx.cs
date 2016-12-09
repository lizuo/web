using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;
using DAL;

namespace 航班延误预测系统
{
    public partial class addDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Data_Check_Click1(object sender, EventArgs e)
        {

        }

        protected void addFlight_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("/App_Data/csv/") + "flight.csv";
            if (!File.Exists(path))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('不存在数据，请上传')", true);
                return;
            }
            using (Database db = new Database())
            {
                string sql = "delete flight_sample";
                db.ExecSql(sql);
                sql = "truncate table flight_sample";//重置数据库标识种子
                db.ExecSql(sql);
            }
            CsvBLL bll = new CsvBLL();
            long start = Environment.TickCount;
            bll.WriteFlightToDB(path);
            long end = Environment.TickCount;
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('写入成功，共花费" +
                ((end - start) / 1000).ToString() + "秒')", true);
        }

        protected void addWeather_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("/App_Data/csv/") + "weather.csv";
            if (!File.Exists(path))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('不存在数据，请上传')", true);
                return;
            }
            using (Database db = new Database())
            {
                string sql = "delete histweather_sample";
                db.ExecSql(sql);
                sql = "truncate table histweather_sample";//重置数据库标识种子
                db.ExecSql(sql);
            }
            CsvBLL bll = new CsvBLL();
            long start = Environment.TickCount;
            bll.WriteWeatherToDB(path);
            long end = Environment.TickCount;
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('写入成功，共花费" +
                ((end - start) / 1000).ToString() + "秒')", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (CsvUpload.HasFile == false)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请选择文件')", true);
                return;
            }
            string Filecsv = System.IO.Path.GetExtension(CsvUpload.FileName).ToString().ToLower();//获得文件的格式
            //判断是否为.csv文件
            if (Filecsv != ".csv")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('只能选择.csv文件！')", true);
                return;
            }

            if (Directory.Exists(Server.MapPath("/App_Data/" + "csv")) == false)//判断用户文件夹是否存在
            {
                Directory.CreateDirectory(Server.MapPath("/App_Data/") + "csv");//创建用户文件夹
                return;
            }
            CsvUpload.SaveAs(Server.MapPath("/App_Data/csv/") + TableID.SelectedValue.Trim() + ".csv");
        }

       
    }
}