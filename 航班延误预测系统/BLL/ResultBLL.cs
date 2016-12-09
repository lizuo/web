using System;
using System.Data;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResultBLL
    {
        public DataSet GetResult(DateTime time, string flightno, string depAir, string arrAir)
        {
            ResultDAL dal = new ResultDAL();
            return dal.GetResult(time, flightno, depAir, arrAir);
        }

        public DataSet GetResult1(DateTime time, string flightno, string depAir, string arrAir)
        {
            ResultDAL dal = new ResultDAL();
            return dal.GetResult1(time, flightno, depAir, arrAir);
        }
    }
}
