using System;
using System.Collections.ObjectModel;

namespace VControl.Controls.VCalendar
{
    public class CalendarModel
    {

        private const int MAX_WEEKS = 6;
        private const int MAX_DAYS = 7;



        private DateTime _currentDate;

        private DayModel[,] currentCalendar;



        public DayModel[,] CurrentCalendar
        {
            get
            {
                return currentCalendar;
            }
        }

        public int CurrentYear
        {
            get
            {
                return _currentDate.Year;
            }
        }

        public int CurrentMonth
        {
            get
            {
                return _currentDate.Month;
            }
        }


        public CalendarModel(DateTime baseDate)
        {
            _currentDate = baseDate;
            MakeCurrentCalendar();
        }

        public void NextMonth()
        {
            _currentDate = _currentDate.AddMonths(1);
            MakeCurrentCalendar();
        }

        public void PriorMonth()
        {
            _currentDate = _currentDate.AddMonths(-1);
            MakeCurrentCalendar();
        }

        private void MakeCurrentCalendar()
        {
            currentCalendar = new DayModel[MAX_WEEKS, MAX_DAYS];

            int lastDay = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);

            DateTime cDate = new DateTime(_currentDate.Year, _currentDate.Month, 1);

            DayModel dayCellAux = null;

            for (int i = 1, line = 0; i <= lastDay; i++)
            {
                int j = Convert.ToInt32(cDate.DayOfWeek);
                dayCellAux = new DayModel(cDate, (line, j));

                currentCalendar[line, j] = dayCellAux;

                if (cDate.DayOfWeek == DayOfWeek.Saturday)
                    line++;

                cDate = cDate.AddDays(1);
                //SetCurrentDate(cDate, dayCellAux);
            }


        }
    }

}
