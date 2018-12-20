using AllAboutShifts.WebApi.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutShifts.WebApi.Services
{
    public class ShiftPlanning
    {
        public int Month { get; set; }
        public int Year { get; set; }

        public IEnumerable<ShiftSlot> Slots { get; set; }

        public IEnumerable<Employee> DayEmployeed(int day)
        {
            var result = new List<Employee>();
            foreach (var x in Slots.Where(x => x.Date.Day == day))
            {
                result.AddRange(x.Employees);
            }

            return result;
        }
    }
}