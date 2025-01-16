using System;
using System.ComponentModel;

namespace VControl.Controls.VCalendar
{
    public class DayModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public DateTime Date { get; protected set; }

        public (int, int) Position { get; protected set; }


        public DayModel(DateTime date, (int, int) position = default)
        {
            Position = position;

            Date = date;
        }

        public static DayModel GetDayNothing()
        {
            return new DayModel(DateTime.MinValue);
        }
    }
}
