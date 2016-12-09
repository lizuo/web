using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataPrep
    {
        //更正航线的错误
        void UpdateRouting()
        {
            using (Database db = new Database())
            {
                string sql = "select distinct flightno,routing,opcar from flight_sample order by flightno";
                DataTable dt = db.GetDataSet(sql).Tables[0];
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i][0] == dt.Rows[i + 1][0])
                    {
                        if (dt.Rows[i]["routing"] != dt.Rows[i + 1]["routing"])
                        {
                            if (dt.Rows[i]["routing"].ToString().StartsWith(dt.Rows[i + 1]["routing"].ToString()))
                            {
                                dt.Rows.RemoveAt(i + 1);
                            }
                            else
                            {
                                dt.Rows.RemoveAt(i);
                            }
                        }
                    }
                }

                sql = "select top 1 * from flightinfo";
                DataTable fdt = db.GetDataSet(sql).Tables[0].Clone();

                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[0]["routing"] == dt.Rows[i]["routing"])
                    {
                        if (dt.Rows[0]["opcar"] != dt.Rows[i]["opcar"])
                        {
                            sql = "select distinct deptime from flight_sample where flightno='" + dt.Rows[0]["flightno"] + "' order by deptime";
                            string t = db.GetDataSet(sql).Tables[0].Rows[0][0].ToString();
                            sql = "select count(*) from flight_sample where flightno='" + dt.Rows[i]["flightno"] + "' and deptime='" + t + "'";
                            if (db.ExecSql(sql) == 1)
                            {
                                if (dt.Rows[0]["opcar"].ToString() == "1")
                                {

                                }
                            }
                        }
                    }
                }


                sql = "select distinct flightno,deptime,depcity,arrcity from flight_sample";
            }
        }

        public void DelRepetition()
        {
            using (Database db = new Database())
            {
                //找出所有重复的记录
                string sql = "select * from (select distinct FlightNo,TimeSeries,DepAirport,count(*) as counts from dbo.flight_sample group by FlightNo,TimeSeries,DepAirport) as t where counts>1";
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    sql = "select id,delaytime from flight_sample where flightno='" +
                        item["FlightNo"].ToString().Trim() + "' and timeseries='" +
                        DateTime.Parse(item["TimeSeries"].ToString()).ToShortDateString() + "' and DepAirport='" +
                        item["DepAirport"].ToString().Trim() + "'";
                    DataSet dss = db.GetDataSet(sql);

                    for (int i = 0; i < dss.Tables[0].Rows.Count - 1; )
                    {
                        if (dss.Tables[0].Rows[i]["delaytime"].ToString() == "")
                        {
                            sql = "delete from flight_sample where id=" + dss.Tables[0].Rows[i]["id"].ToString().Trim();
                            db.ExecSql(sql);
                            dss.Tables[0].Rows.RemoveAt(i);
                            continue;
                        }
                        if (dss.Tables[0].Rows[i + 1]["delaytime"].ToString() == "")
                        {
                            sql = "delete from flight_sample where id=" + dss.Tables[0].Rows[i+1]["id"].ToString().Trim();
                            db.ExecSql(sql);
                            dss.Tables[0].Rows.RemoveAt(i + 1);
                            continue;
                        }
                        int j = (int)dss.Tables[0].Rows[i]["delaytime"];
                        int k = (int)dss.Tables[0].Rows[i + 1]["delaytime"];
                        if (j < 0)
                        {
                            j = -j;
                        }
                        if (k < 0)
                        {
                            k = -k;
                        }
                        if (j > k)
                        {
                            sql = "delete from flight_sample where id=" + dss.Tables[0].Rows[i]["id"].ToString().Trim();
                            db.ExecSql(sql);
                            dss.Tables[0].Rows.RemoveAt(i);
                        }
                        else
                        {
                            sql = "delete from flight_sample where id=" + dss.Tables[0].Rows[i + 1]["id"].ToString().Trim();
                            db.ExecSql(sql);
                            dss.Tables[0].Rows.RemoveAt(i + 1);
                            i++;
                        }
                    }
                    
                }
            }
        }



    }
}
