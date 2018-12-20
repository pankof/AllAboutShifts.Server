using AllAboutShifts.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Entities
{
    public class ShiftSlot
    {
        public DateTime Date { get; set; }
        public string ShiftName { get; set; }
        public List<Employee> Employees { get; set; }
        public bool IsBasicShift { get; set; }

        public ShiftSlot(DateTime date, string shiftName, bool isBasicShift)
        {
            Date = date;
            ShiftName = shiftName;
            IsBasicShift = isBasicShift;
        }

        public void CreateEmtySlots(int count)
        {
            Employees = new List<Employee>(new Employee[count]);
        }

        public void AddEmptyEmployee(int count)
        {
            Employees.AddRange(new Employee[count]);
        }

        public bool IsBasicSlot()
        {
            return Date.IsWeekDay() && IsBasicShift;
        }

    }
}
