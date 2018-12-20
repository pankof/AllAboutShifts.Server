using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Entities
{
    public class ShiftTemplate
    {
        public IEnumerable<ShiftHour> ShiftsHours { get; set; }
        public string BasicShift { get; set; }
        public int NoOfEmployees { get; set; }
    }
}
