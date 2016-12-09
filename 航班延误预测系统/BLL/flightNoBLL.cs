using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class flightNoBLL
    {
        flightNoDAL dal = new flightNoDAL();
        public DataSet getFlightNo(DateTime date)
        {
            return dal.getFlightNo(date);
        }
        public DataSet getdepAir()
        {
            return dal.getdepAir();
        }
        public DataSet getarrAir()//获得到达机场三字码
        {
            return dal.getarrAir();
        }
    }
}
