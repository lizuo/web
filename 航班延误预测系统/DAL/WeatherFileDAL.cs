using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WeatherFileDAL : CSVFileDAL
    {
        public override void WriteToDatabase()
        {
            using (Database db = new Database())
            {
                DataTable dt = db.GetDataSet("select top 1 * from histweather_sample").Tables[0].Clone();
                int rowCount = 0;
                string line = "";
                strReader.ReadLine();
                while ((line = strReader.ReadLine()) != null)
                {
                    string[] list = line.Split(',');
                    DataRow dr = dt.NewRow();

                    if (list[1] == "" || list[2] == "" || list[3] == "" || list[4] == "" ||
                        list[5] == "" || list[6] == "" || list[7] == "" || list[8] == "")
                    {
                        continue;
                    }
                    else
                    {
                        dr["city"] = list[1];
                        dr["cityname"] = list[2];
                        dr["date"] = list[3];
                        dr["temphi"] = list[4];
                        dr["templow"] = list[5];
                        dr["description"] = list[6];
                        dr["windir"] = list[7];
                        dr["windstrength"] = list[8];
                    }

                    if (list[9] != "")
                    {
                        dr["aqi"] = list[9];
                    }

                    if (list[11] != "")
                    {
                        dr["aqilevel"] = list[11];
                    }
                    
                    dr["aqiinfo"] = list[10];
                    
                    dt.Rows.Add(dr);
                    rowCount++;
                    if (rowCount == 10000)
                    {
                        db.CopyToDataBase(dt, "histweather_sample");
                        dt.Clear();
                        rowCount = 0;
                    }
                }
                if (rowCount != 0)
                {
                    db.CopyToDataBase(dt, "histweather_sample");
                    dt.Clear();
                }
            }
        }

        public WeatherFileDAL(string path)
            : base(path)
        { }
    }
}
