using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{

    public class flightNoDAL
    {
        Database db = new Database();
        public DataSet getFlightNo(DateTime date)//获得航班号
        {
            string sql = "select distinct FlightNo from dbo.flight_sample where TimeSeries='" + date + "' order by flightno";
            DataSet ds = db.GetDataSet(sql);
            return ds;
        }

        public DataSet getdepAir()//获得出发机场三字码
        {
            string sql = "select distinct DepAirport from dbo.flight_sample order by depairport";
            DataSet ds = db.GetDataSet(sql);
            return ds;
        }

        public DataSet getarrAir()//获得到达机场三字码
        {
            string sql = "select distinct ArrAirport from dbo.flight_sample order by arrairport";
            DataSet ds = db.GetDataSet(sql);
            return ds;
        }
    }
}
