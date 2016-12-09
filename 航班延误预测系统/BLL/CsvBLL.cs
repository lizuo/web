using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class CsvBLL
    {
        public void WriteFlightToDB(string path)
        {
            using (FlightFileDAL dal = new FlightFileDAL(path))
            {
                dal.WriteToDatabase();
            }
            //DataPrep dp = new DataPrep();
            //dp.DelRepetition();
        }

        public void WriteWeatherToDB(string path)
        {
            using (WeatherFileDAL dal = new WeatherFileDAL(path))
            {
                dal.WriteToDatabase();
            }
        }
    }
}
