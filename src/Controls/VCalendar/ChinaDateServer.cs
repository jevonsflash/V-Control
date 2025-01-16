using System;
using System.Collections;
using System.Globalization;

namespace VControl.Controls.VCalendar
{
    public class ChinaDateServer
    {




        #region 农历信息获取  

        private ChineseLunisolarCalendar china = new ChineseLunisolarCalendar();

        private Hashtable gHoliday = new Hashtable();

        private Hashtable nHoliday = new Hashtable();

        private string[] JQ = { "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };

        private int[] JQData = { 0, 21208, 43467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };


        public ChinaDateServer()

        {

            //公历节日  

            gHoliday.Add("0101", "元旦");

            gHoliday.Add("0214", "情人节");

            gHoliday.Add("0305", "雷锋日");

            gHoliday.Add("0308", "妇女节");

            gHoliday.Add("0312", "植树节");

            gHoliday.Add("0315", "消费者权益日");

            gHoliday.Add("0401", "愚人节");

            gHoliday.Add("0501", "劳动节");

            gHoliday.Add("0504", "青年节");

            gHoliday.Add("0601", "儿童节");

            gHoliday.Add("0701", "建党节");

            gHoliday.Add("0801", "建军节");

            gHoliday.Add("0910", "教师节");

            gHoliday.Add("1001", "国庆节");

            gHoliday.Add("1224", "平安夜");

            gHoliday.Add("1225", "圣诞节");


            //农历节日  

            nHoliday.Add("0101", "春节");

            nHoliday.Add("0115", "元宵节");

            nHoliday.Add("0505", "端午节");

            nHoliday.Add("0815", "中秋节");

            nHoliday.Add("0909", "重阳节");

            nHoliday.Add("1208", "腊八节");

        }


        /// <summary>  

        /// 获取农历  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetChinaDate(DateTime dt)

        {

            if (dt > china.MaxSupportedDateTime || dt < china.MinSupportedDateTime)

            {

                //日期范围：1901 年 2 月 19 日 - 2101 年 1 月 28 日  

                throw new Exception(string.Format("日期超出范围！必须在{0}到{1}之间！", china.MinSupportedDateTime.ToString("yyyy-MM-dd"), china.MaxSupportedDateTime.ToString("yyyy-MM-dd")));

            }

            string str = string.Format("{0} {1}{2}", GetYear(dt), GetMonth(dt), GetDay(dt));

            string strJQ = GetSolarTerm(dt);

            if (strJQ != "")

            {

                str += " (" + strJQ + ")";

            }

            string strHoliday = GetHoliday(dt);

            if (strHoliday != "")

            {

                str += " " + strHoliday;

            }

            string strChinaHoliday = GetChinaHoliday(dt);

            if (strChinaHoliday != "")

            {

                str += " " + strChinaHoliday;

            }


            return str;

        }


        /// <summary>  

        /// 获取农历年份  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetYear(DateTime dt)

        {

            int yearIndex = china.GetSexagenaryYear(dt);

            string yearTG = " 甲乙丙丁戊己庚辛壬癸";

            string yearDZ = " 子丑寅卯辰巳午未申酉戌亥";

            string yearSX = " 鼠牛虎兔龙蛇马羊猴鸡狗猪";

            int year = china.GetYear(dt);

            int yTG = china.GetCelestialStem(yearIndex);

            int yDZ = china.GetTerrestrialBranch(yearIndex);


            string str = string.Format("[{1}]{2}{3}{0}", year, yearSX[yDZ], yearTG[yTG], yearDZ[yDZ]);

            return str;

        }


        /// <summary>  

        /// 获取农历月份  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetMonth(DateTime dt)

        {

            int year = china.GetYear(dt);

            int iMonth = china.GetMonth(dt);

            int leapMonth = china.GetLeapMonth(year);

            bool isLeapMonth = iMonth == leapMonth;

            if (leapMonth != 0 && iMonth >= leapMonth)

            {

                iMonth--;

            }


            string szText = "正二三四五六七八九十";

            string strMonth = isLeapMonth ? "闰" : "";

            if (iMonth <= 10)

            {

                strMonth += szText.Substring(iMonth - 1, 1);

            }

            else if (iMonth == 11)

            {

                strMonth += "十一";

            }

            else

            {

                strMonth += "腊";

            }

            return strMonth + "月";

        }


        /// <summary>  

        /// 获取农历日期  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetDay(DateTime dt)

        {

            int iDay = china.GetDayOfMonth(dt);

            string szText1 = "初十廿三";

            string szText2 = "一二三四五六七八九十";

            string strDay;

            if (iDay == 20)

            {

                strDay = "二十";

            }

            else if (iDay == 30)

            {

                strDay = "三十";

            }

            else

            {

                strDay = szText1.Substring((iDay - 1) / 10, 1);

                strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);

            }

            return strDay;

        }


        /// <summary>  

        /// 获取节气  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetSolarTerm(DateTime dt)

        {

            DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);

            DateTime dtNew;

            double num;

            int y;

            string strReturn = "";


            y = dt.Year;

            for (int i = 1; i <= 24; i++)

            {

                num = 525948.76 * (y - 1900) + JQData[i - 1];

                dtNew = dtBase.AddMinutes(num);

                if (dtNew.DayOfYear == dt.DayOfYear)

                {

                    strReturn = JQ[i - 1];

                }

            }


            return strReturn;

        }


        /// <summary>  

        /// 获取公历节日  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetHoliday(DateTime dt)

        {

            string strReturn = "";

            object g = gHoliday[dt.Month.ToString("00") + dt.Day.ToString("00")];

            if (g != null)

            {

                strReturn = g.ToString();

            }


            return strReturn;

        }


        /// <summary>  

        /// 获取农历节日  

        /// </summary>  

        /// <param name="dt"></param>  

        /// <returns></returns>  

        public string GetChinaHoliday(DateTime dt)

        {

            string strReturn = "";

            int year = china.GetYear(dt);

            int iMonth = china.GetMonth(dt);

            int leapMonth = china.GetLeapMonth(year);

            int iDay = china.GetDayOfMonth(dt);

            if (china.GetDayOfYear(dt) == china.GetDaysInYear(year))

            {

                strReturn = "除夕";

            }

            else if (leapMonth != iMonth)

            {

                if (leapMonth != 0 && iMonth >= leapMonth)

                {

                    iMonth--;

                }

                object n = nHoliday[iMonth.ToString("00") + iDay.ToString("00")];

                if (n != null)

                {

                    if (strReturn == "")

                    {

                        strReturn = n.ToString();

                    }

                    else

                    {

                        strReturn += " " + n.ToString();

                    }

                }

            }


            return strReturn;

        }

        #endregion


        #region 阴历-阳历-转换  

        /// <summary>  

        /// 阴历转为阳历  

        /// </summary>  

        /// <param name="year">指定的年份</param>  

        public DateTime GetLunarYearDate(DateTime dt)

        {

            int cnYear = china.GetYear(dt);

            int cnMonth = china.GetMonth(dt);


            int num1 = 0;

            int num2 = china.IsLeapYear(cnYear) ? 13 : 12;


            while (num2 >= cnMonth)

            {

                num1 += china.GetDaysInMonth(cnYear, num2--);

            }


            num1 = num1 - china.GetDayOfMonth(dt) + 1;

            return dt.AddDays(num1);

        }

        /// <summary>  

        /// 阳历转为阴历  

        /// </summary>  

        /// <param name="dt">公历日期</param>  

        /// <returns>农历的日期</returns>  

        public DateTime GetSunYearDate(DateTime dt)

        {

            int year = china.GetYear(dt);

            int iMonth = china.GetMonth(dt);

            int iDay = china.GetDayOfMonth(dt);

            int leapMonth = china.GetLeapMonth(year);

            bool isLeapMonth = iMonth == leapMonth;

            if (leapMonth != 0 && iMonth >= leapMonth)

            {

                iMonth--;

            }

            string str = string.Format("{0}-{1}-{2}", year, iMonth, iDay);

            DateTime dtNew = DateTime.Now;

            try

            {

                dtNew = Convert.ToDateTime(str); //防止出现2月份时，会出现超过时间，出现“2015-02-30”这种错误日期  

            }

            catch

            {

            }

            return dtNew;

        }

        #endregion

    }
}