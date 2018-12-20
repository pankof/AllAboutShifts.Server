using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Entities
{
    public class ShiftHour
    {
        public string Name { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int NoOfEmployeesWeekDays { get; set; }
        public int NoOfEmployeesWeekend { get; set; }
    }
}
