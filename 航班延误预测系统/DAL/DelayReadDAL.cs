using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class DelayReadDAL
    {
        public void ReadData(Flight f)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            for (int i = 0; i < 10000; i++)
            {
                dr["id"] = f.Id;
                dr["FlightNo"] = f.FlightNo;
                dr["DelayTime"] = f.DelayTime;
                dr["Isdelay"] = f.Isdelay;
                dt.Rows.Add(dr);
            }          
        }
    }
}
