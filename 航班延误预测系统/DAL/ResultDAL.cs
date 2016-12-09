using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ResultDAL
    {
        Database db = null;
        public DataSet GetResult(DateTime time, string flightno, string depAir, string arrAir)
        {
            using (db = new Database())
            {
                flightno = flightno.Trim();
                int a = int.Parse(flightno.Substring(flightno.Length - 2, 1));
                if (a % 2 == 0)
                {
                    string fno = flightno.Substring(0, flightno.Length - 1) + (a - 1).ToString();

                    string sql = "select count(*) from flight_sample where flightno='" +
                        fno + "' and timeseries='" + time.ToShortDateString() + "' and isdelay in(1,0)";
                    if (db.ExecSql(sql) > 0)
                    {
                        return Fun2(flightno, fno, time, depAir);
                    }
                    else
                    {
                        return Fun3(flightno, fno, depAir, arrAir);
                    }

                }
                else
                {
                    return Fun1(time, flightno, depAir, arrAir);
                }
            }
        }

        /// <summary>
        /// 只考虑天气因数
        /// </summary>
        /// <returns></returns>
        DataSet Fun1(DateTime time, string flightno, string depAir, string arrAir)
        {
            //查出预测当天起飞城市的天气情况
            string sql = "select w.description from histweather_sample as w join (select TimeSeries,DepCity from flight_sample where flightno='" +
                    flightno.Trim() + "' and timeseries='" + time.ToShortDateString()
                    + "' and depairport='" + depAir.Trim() + "' and arrairport='" + arrAir.Trim() + "') as f"
                    + " on w.date=f.TimeSeries and w.city=f.DepCity";
            string yuceW = db.ExecScalar(sql).ToString();

            //查出预测当天目的城市的天气情况
            sql = "select w.description from histweather_sample as w join (select TimeSeries,ArrCity from flight_sample where flightno='" +
                    flightno.Trim() + "' and timeseries='" + time.ToShortDateString()
                    + "' and depairport='" + depAir.Trim() + "' and arrairport='" + arrAir.Trim() + "') as f"
                    + " on w.date=f.TimeSeries and w.city=f.ArrCity";
            string mudiW = db.ExecScalar(sql).ToString();

            if (yuceW == "晴")
            {
                if (mudiW == "晴")
                {
                    return ToDataSet(flightno, time, 0);
                }
                else
                {

                }
                sql = "select * from flight_sample as f left join histweather_sample as w on f.depcity=w.city and f.timeseries=w.date";
            }
            else if(yuceW == "多云")
            {

            }

            //查询统计航班延误是各天气延误情况
            sql = "select w.description,count(*) as counts from histweather_sample as w join (select TimeSeries,DepCity from flight_sample where flightno='" +
                    flightno.Trim() + "' and timeseries<='2016/3/31' and depairport='" + depAir.Trim() + "' and arrairport='" + arrAir.Trim() + "' and isdelay=1) as f"
                    + " on w.date=f.TimeSeries and w.city=f.DepCity group by w.description order by counts";
            DataSet delayByW = db.GetDataSet(sql);

            //查看预测的当天天气是否在delayByW中
            int counts = 0;
            foreach (DataRow item in delayByW.Tables[0].Rows)
            {
                if (item["description"].ToString() == yuceW)
                {
                    counts = int.Parse(item["counts"].ToString());
                    break;
                }
            }

            if (counts > 0)
            {
                //counts大于1，认为非偶然，否则可认为为偶然
                if (counts > 1)
                {
                    
                }
                else
                {

                }
            }

            return null;
        }

        /// <summary>
        /// 与前序航班相关
        /// </summary>
        /// <param name="fno"></param>
        /// <returns></returns>
        DataSet Fun2(string flightno, string fno, DateTime time, string depAir)
        {
            string sql = "select delaytime from flight_sample where flightno='" + fno.Trim()
                + "' and timeseries='" + time.ToShortDateString() + "' and depairport='" + depAir.Trim() + "'";
            DataSet ds = db.GetDataSet(sql);
            return ToDataSet(flightno, time, int.Parse(ds.Tables[0].Rows[0][0].ToString()));
        }

        /// <summary>
        /// 综合考虑
        /// </summary>
        /// <param name="flightno"></param>
        /// <param name="fno"></param>
        /// <param name="depAir"></param>
        /// <param name="arrAir"></param>
        /// <returns></returns>
        DataSet Fun3(string flightno, string fno, string depAir, string arrAir)
        {

            return null;
        }

        DataSet ToDataSet(string flightno, DateTime time, int DelayTime)
        {
            string sql = "select deptime,arrtime,arrday,flyingtime from flight_sample where flightno='" +
                flightno.Trim() + "' and timeseries='" + time.ToShortDateString() + "'";
            DataSet dss = db.GetDataSet(sql);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("flight_no", typeof(string)));
            dt.Columns.Add(new DataColumn("plan_dep_date", typeof(string)));
            dt.Columns.Add(new DataColumn("plan_arv_date", typeof(string)));
            dt.Columns.Add(new DataColumn("plan_dep_time", typeof(string)));
            dt.Columns.Add(new DataColumn("plan_arv_time", typeof(string)));
            dt.Columns.Add(new DataColumn("fcst_dep_date", typeof(string)));
            dt.Columns.Add(new DataColumn("fcst_arv_date", typeof(string)));
            dt.Columns.Add(new DataColumn("fcst_dep_time", typeof(string)));
            dt.Columns.Add(new DataColumn("fcst_arv_time", typeof(string)));
            dt.Columns.Add(new DataColumn("is_delayed", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["flight_no"] = flightno;
            dr["plan_dep_date"] = time.ToShortDateString();
            dr["plan_arv_date"] = time.AddDays(double.Parse(dss.Tables[0].Rows[0]["arrday"].ToString())).ToShortDateString();
            dr["plan_dep_time"] = dss.Tables[0].Rows[0]["deptime"].ToString();
            dr["plan_arv_time"] = dss.Tables[0].Rows[0]["arrtime"].ToString();
            //dr["fcst_dep_date"] = time.AddMinutes(DelayTime).ToShortDateString();
            //dr["fcst_arv_date"] = time.AddMinutes(DelayTime + int.Parse(dss.Tables[0].Rows[0]["flyingtime"].ToString())).ToShortDateString();

            int d = (int)((TimeSpan)dss.Tables[0].Rows[0]["deptime"]).TotalMinutes + DelayTime;
            if (d >= 24 * 60)
            {
                dr["fcst_dep_time"] = (new TimeSpan((d - 24 * 60) * TimeSpan.TicksPerMinute)).ToString();
                dr["fcst_dep_date"] = time.AddMinutes(1).ToShortDateString();
            }
            else
            {
                dr["fcst_dep_time"] = (new TimeSpan(d * TimeSpan.TicksPerMinute)).ToString();
                dr["fcst_dep_date"] = time.ToShortDateString();
            }

            d += int.Parse(dss.Tables[0].Rows[0]["flyingtime"].ToString());
            if (d >= 24 * 60)
            {
                dr["fcst_arv_time"] = (new TimeSpan((d - 24 * 60) * TimeSpan.TicksPerMinute)).ToString();
                dr["fcst_arv_date"] = time.AddMinutes(1).ToShortDateString();

            }
            else
            {
                dr["fcst_arv_time"] = (new TimeSpan(d * TimeSpan.TicksPerMinute)).ToString();
                dr["fcst_arv_date"] = time.ToShortDateString();
            }

            if (DelayTime >= 30)
            {
                dr["is_delayed"] = "是";
            }
            else
            {
                dr["is_delayed"] = "否";
            }
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);

            return ds;
        }

        void SeeWeather(DateTime time, string flightno, string depAir)
        {
            using (Database db = new Database())
            {
                string sql = "select description,windstrength from dbo.histweather_sample as w" +
                    "join (select TimeSeries,DepCity from dbo.flight_sample where TimeSeries='" +
                    time.ToShortDateString().Trim() + "' and FlightNo='" +
                    flightno.Trim() + "' and DepAirport='" + depAir.Trim() + "') as t" +
                    "on w.date=t.TimeSeries and w.city = t.DepCity";
                DataSet ds = db.GetDataSet(sql);
                string[] weathers = ds.Tables[0].Rows[0][1].ToString().Split('~');
                foreach (string item in weathers)
                {

                }
            }
        }


        public DataSet GetResult1(DateTime time, string flightno, string depAir, string arrAir)
        {
            using (db = new Database())
            {
                string sql = "select w.description from histweather_sample as w join (select TimeSeries,DepCity from flight_sample where flightno='" +
                    flightno.Trim() + "' and timeseries='" + time.ToShortDateString()
                    + "' and depairport='" + depAir.Trim() + "' and arrairport='" + arrAir.Trim() + "') as f"
                    + " on w.date=f.TimeSeries and w.city=f.DepCity";
                string des = db.ExecScalar(sql).ToString().Trim();
                sql = "select count(*) from histweather_sample as w join (select TimeSeries,DepCity,delaytime from flight_sample where flightno='" +
                    flightno.Trim() + "' and timeseries<='" + time.ToShortDateString()
                    + "' and depairport='" + depAir.Trim() + "' and arrairport='" + arrAir.Trim() + "') as f"
                    + " on w.date=f.TimeSeries and w.city=f.DepCity where w.description='" + des + "' and f.delaytime>=0 and f.delaytime<=120";
                int counts = int.Parse(db.ExecScalar(sql).ToString());
                if (counts > 0)
                {
                    sql = "select sum(delaytime) from histweather_sample as w join (select TimeSeries,DepCity,delaytime from flight_sample where flightno='" +
                        flightno.Trim() + "' and timeseries<='" + time.ToShortDateString()
                        + "' and depairport='" + depAir.Trim() + "' and arrairport='" + arrAir.Trim() + "') as f"
                        + " on w.date=f.TimeSeries and w.city=f.DepCity where w.description='" + des + "' and f.delaytime>=0 and f.delaytime<=120";
                    int sum = int.Parse(db.ExecScalar(sql).ToString());

                    return ToDataSet(flightno, time, sum / counts);
                }
                else
                {
                    return ToDataSet(flightno, time, 0);
                }
                
            }
        }
    }
}
