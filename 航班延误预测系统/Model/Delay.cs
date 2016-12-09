using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Delay
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string flightNo;

        public string FlightNo
        {
            get { return flightNo; }
            set { flightNo = value; }
        }
        bool isdelay;

        public bool Isdealy
        {
            get { return isdelay; }
            set { isdelay = value; }
        }
        int delayTime;

        public int DelayTime
        {
            get { return delayTime; }
            set { delayTime = value; }
        }
    }
}
