using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlightFileDAL : CSVFileDAL
    {
        public override void WriteToDatabase()
        {
            using (Database db = new Database())
            {
                DataTable dt = db.GetDataSet("select top 1 * from flight_sample").Tables[0].Clone();
                int rowCount = 0;
                string line = "";
                strReader.ReadLine();
                while ((line = strReader.ReadLine()) != null)
                {
                    string[] list = line.Split(',');
                    DataRow dr = dt.NewRow();

                    //try
                    //{
                    if (list[17] == "" || list[17] == "取消" || list[17] == "未知")
                    {
                        dr["TimeSeries"] = list[1];

                        if (list[2] == "")
                        {
                            if (list[3] != "" && list[4] != "")
                            {
                                list[2] = list[3] + list[4];
                                dr["FlightNo"] = list[2];
                            }
                            else
                                continue;
                        }
                        else
                        {
                            dr["FlightNo"] = list[2];
                        }

                        if (list[10] == "" || list[9] == ""
                            || list[11] == "" || list[12] == "" || list[18] == "")
                        {
                            continue;
                        }
                        else
                        {
                            dr["Arrday"] = list[11];
                            dr["DepTime"] = list[9];
                            dr["ArrTime"] = list[10];
                            dr["FlyingTime"] = list[12];
                            dr["Stops"] = list[18];
                        }

                        if (list[16] + list[15] + list[14] + list[13] != "")
                        {
                            if (list[16] == "")
                            {
                                if (list[17] == "取消")
                                {
                                    dr["ActFlyingTime"] = 0;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                dr["ActFlyingTime"] = list[16];

                            }

                            if (list[15] == "")
                            {
                                if (list[17] == "")
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                dr["ActArrday"] = list[15];
                            }


                            if (list[13] == "" || list[14] == "")
                            {
                                if (list[17] == "")
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                dr["ActDepTime"] = list[13];
                                dr["ActArrTime"] = list[14];
                            }

                            TimeSpan t = (TimeSpan)dr["ActDepTime"] - (TimeSpan)dr["DepTime"];
                            dr["DelayTime"] = t.TotalMinutes;
                            if (t.TotalMinutes >= 30)
                            {
                                dr["IsDelay"] = 1;
                            }
                            else
                            {
                                dr["IsDelay"] = 0;
                            }
                        }

                        dr["Carrier"] = list[3];
                        dr["FlightNoShort"] = list[4];
                        dr["DepAirport"] = list[5];
                        dr["DepCity"] = list[6];
                        dr["ArrAirport"] = list[7];
                        dr["ArrCity"] = list[8];
                        dr["Comment"] = list[17];
                        dr["Routing"] = list[19];
                        dr["Acft"] = list[20];
                        dr["DistKm"] = list[21];
                        dr["OpCar"] = list[22] == "O" ? 1 : 0;

                        dt.Rows.Add(dr);
                        rowCount++;
                    }
                    //}
                    //catch
                    //{
                    //    continue;
                    //}

                    if (rowCount == 10000)
                    {
                        db.CopyToDataBase(dt, "flight_sample");
                        dt.Clear();
                        rowCount = 0;
                    }
                }
                if (rowCount != 0)
                {
                    db.CopyToDataBase(dt, "flight_sample");
                    dt.Clear();
                }
            }
        }

        public FlightFileDAL(string path)
            : base(path)
        { }
    }
}
