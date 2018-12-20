using AllAboutShifts.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Entities
{
    public class EmployeeBalance
    {
        public Employee Employee { get; set; }
        public List<Shift> WorkingDates { get; set; } = new List<Shift>();
        public Dictionary<string, int> WeekdaysBalance { get; set; }
        public Dictionary<string, int> WeekendsBalance { get; set; }
        public int WeekWorkingDays { get; set; }
        public int Ranking { get; set; }

        public EmployeeBalance(Employee employee, IEnumerable<ShiftHour> shiftHours)
        {
            Employee = employee;
            WeekdaysBalance = new Dictionary<string, int>();
            WeekendsBalance = new Dictionary<string, int>();

            foreach (var shift in shiftHours)
            {
                WeekdaysBalance.Add(shift.Name, 0);
                WeekendsBalance.Add(shift.Name, 0);
            }
        }

        public void AddWorkingDay(DateTime date, string shiftname)
        {
            var shift = new Shift(date, shiftname);
            WorkingDates.Add(shift);

            if (date.IsWeekDay())
                WeekdaysBalance[shiftname]++;
            else
                WeekendsBalance[shiftname]++;

            WeekWorkingDays++;
        }

        public int EmployeeRanking(DateTime date, string shiftname)
        {
            if (WeekWorkingDays == 5)
                return -1;

            var rank = date.IsWeekDay() ? WeekdayRanking(date, shiftname) : WeekendRanking(date, shiftname);

            return rank;
        }
        public void CalculateRanking(DateTime date, string shiftname)
        {
            if (WeekWorkingDays == 5)
            {
                Ranking = -1;
                return;
            }

            Ranking = date.IsWeekDay() ? WeekdayRanking(date, shiftname) : WeekendRanking(date, shiftname);
        }

        private int WeekdayRanking(DateTime date, string shiftname)
        {
            if (WorkingDates.Any(x => x.Date.Day == date.Day && x.Date.Month == x.Date.Month))
                return -1;

            var shiftRank = WeekdaysBalance[shiftname];

            return 100 - shiftRank;
        }

        private int WeekendRanking(DateTime date, string shiftname)
        {
            if (WorkingDates.Any(x => x.Date.Day == date.Day && x.Date.Month == x.Date.Month))
                return -1;

            var shiftRank = WeekendsBalance[shiftname];

            return 100 - shiftRank;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
