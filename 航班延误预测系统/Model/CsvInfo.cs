using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class CsvInfo
    {
        public static string[] flightTitle = { "TimeSeries", "FlightNo", "Carrier",
                                                "FlightNoShort", "DepAirport", "DepCity",
                                                "ArrAirport", "ArrCity", "DepTime", "ArrTime",
                                                "Arrday", "FlyingTime", "ActDepTime", "ActArrTime",
                                                "ActArrday", "ActFlyingTime", "Comment",
                                                "Stops", "Routing", "Acft", "DistKm", "OpCar" };

        public static string[] weatherTitle = { "city", "cityname", "date",
                                                "temphi", "templow", "description",
                                                "windir", "windstrength", "aqi", "aqiinfo", "aqilevel" };

        DataTable csvStruct = null;

        public DataTable CsvStruct
        {
            get { return csvStruct; }
            set { csvStruct = value; }
        }

        public int TitleCount   //title数量
        {
            get { return csvStruct.Columns.Count; }
        }

        public CsvInfo(string[] title)
        {
            csvStruct = new DataTable();
            foreach (string item in title)
            {
                csvStruct.Columns.Add(new DataColumn(item));
            }
        }
    }
}
