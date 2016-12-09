using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //城市天气情况
    class Wearther
    {
        int id;
        //编号
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string city;
        //城市三字码
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        string cityName;
        //城市名字
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        DateTime date;
        //日期
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        int temphi;
        //最高温度
        public int Temphi
        {
            get { return temphi; }
            set { temphi = value; }
        }

        int temlow;
        //最低温度
        public int Temlow
        {
            get { return temlow; }
            set { temlow = value; }
        }

        string description;
        //天气描述
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        string windir;
        //风向
        public string Windir
        {
            get { return windir; }
            set { windir = value; }
        }

        int windstrenght;
        //风力
        public int Windstrenght
        {
            get { return windstrenght; }
            set { windstrenght = value; }
        }

        int aqi;
        //空气指数
        //-1表示为空
        public int Aqi
        {
            get { return aqi; }
            set { aqi = value; }
        }

        string aqiinfo;
        //空气质量描述
        //若aqi为空，此变量必为空
        public string Aqiinfo
        {
            get { return aqiinfo; }
            set { aqiinfo = value; }
        }

        int aqilevel;
        //空气质量级别
        //若aqi为空，此变量必为空
        public int Aqilevel
        {
            get { return aqilevel; }
            set { aqilevel = value; }
        }

    }
}
