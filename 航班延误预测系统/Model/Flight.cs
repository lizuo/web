using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //航班历史记录
    public class Flight
    {
        int id;
        //编号
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        DateTime timeSeries;
        //日期
        public DateTime TimeSeries
        {
            get { return timeSeries; }
            set { timeSeries = value; }
        }

        string flightNo;
        //完整航班号
        public string FlightNo
        {
            get { return flightNo; }
            set { flightNo = value; }
        }

        string carrier;
        //航班公司代号
        public string Carrier
        {
            get { return carrier; }
            set { carrier = value; }
        }

        string flightNoShot;
        //航班号（去前缀后的号码）
        public string FlightNoShot
        {
            get { return flightNoShot; }
            set { flightNoShot = value; }
        }

        string depAirport;
        //出发机场三字码
        public string DepAirport
        {
            get { return depAirport; }
            set { depAirport = value; }
        }

        string depCity;
        //出发城市三字码
        public string DepCity
        {
            get { return depCity; }
            set { depCity = value; }
        }

        string arrAriport;
        //目的机场三字码
        public string ArrAriport
        {
            get { return arrAriport; }
            set { arrAriport = value; }
        }

        string arrCity;
        //目的城市三字码
        public string ArrCity
        {
            get { return arrCity; }
            set { arrCity = value; }
        }

        DateTime depTime;
        //计划出发时间
        //低16位记录小时 高16位记录分钟
        public DateTime DepTime
        {
            get { return depTime; }
            set { depTime = value; }
        }

        DateTime arrTime;
        //实际出发时间
        //低16位记录小时 高16位记录分钟
        public DateTime ArrTime
        {
            get { return arrTime; }
            set { arrTime = value; }
        }

        int arrDay;
        //计划到达日
        //0为当天到达，1为第二天，以此类推
        public int ArrDay
        {
            get { return arrDay; }
            set { arrDay = value; }
        }

        int flyingTime;
        //计划飞行时间 以分为单位
        public int FlyingTime
        {
            get { return flyingTime; }
            set { flyingTime = value; }
        }

        DateTime actDepTime;
        //实际出发时间
        //低16位记录小时 高16位记录分钟
        public DateTime ActDepTime
        {
            get { return actDepTime; }
            set { actDepTime = value; }
        }

        DateTime actArrTime;
        //实际到达时间
        //低16位记录小时 高16位记录分钟
        public DateTime ActArrTime
        {
            get { return actArrTime; }
            set { actArrTime = value; }
        }

        int actArrDay;
        //实际到达日
        //0为当天到达，1为第二天，以此类推
        public int ActArrDay
        {
            get { return actArrDay; }
            set { actArrDay = value; }
        }

        int actFlyingTime;
        //实际飞行时间 以分为单位
        public int ActFlyingTime
        {
            get { return actFlyingTime; }
            set { actFlyingTime = value; }
        }

        string comment;
        //备注
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        int stops;
        //经停次数
        public int Stops
        {
            get { return stops; }
            set { stops = value; }
        }

        string routing;
        //航线
        //以'-'连接的机场三字码串
        public string Routing
        {
            get { return routing; }
            set { routing = value; }
        }

        string acft;
        //机型
        public string Acft
        {
            get { return acft; }
            set { acft = value; }
        }

        int dismKm;
        //距离
        //单位千米
        public int DismKm
        {
            get { return dismKm; }
            set { dismKm = value; }
        }

        bool opCar;
        //是否是实际承运的航班
        public bool OpCar
        {
            get { return opCar; }
            set { opCar = value; }
        }

        int delayTime;
        public int DelayTime
        {
            get { return delayTime; }
            set { delayTime = value; }
        }

        bool isdelay;
        public bool Isdelay
        {
            get { return isdelay; }
            set { isdelay = value; }
        }
        
    }
}
