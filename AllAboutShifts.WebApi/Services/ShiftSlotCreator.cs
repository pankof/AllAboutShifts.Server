using AllAboutShifts.WebApi.Common;
using AllAboutShifts.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Services
{
    public class ShiftSlotCreator
    {
        int _month;
        int _year;
        ShiftTemplate _shiftTemplate;

        public ShiftSlotCreator(ShiftTemplate shiftTemplate, int month, int year)
        {
            _shiftTemplate = shiftTemplate;
            _month = month;
            _year = year;
        }

        public IEnumerable<ShiftSlot> Create()
        {
            var slots = CreateEmptySlots();

            AssignRemainingOnBasicSlots(slots);

            return slots;
        }

        private List<ShiftSlot> CreateEmptySlots()
        {
            var slots = new List<ShiftSlot>();

            foreach (var date in DateUtilities.AllDatesInMonth(_month, _year))
            {
                foreach (var shiftHour in _shiftTemplate.ShiftsHours)
                {
                    var slot = new ShiftSlot(date, shiftHour.Name, shiftHour.Name == _shiftTemplate.BasicShift);
                    slot.CreateEmtySlots(date.IsWeekDay() ? shiftHour.NoOfEmployeesWeekDays : shiftHour.NoOfEmployeesWeekend);

                    slots.Add(slot);
                }
            }

            return slots;
        }

        private void AssignRemainingOnBasicSlots(List<ShiftSlot> slots)
        {
            var workingDays = DateUtilities.AllDatesInMonth(_month, _year).Count(x => x.IsWeekDay());
            var employeesAvailableWorkingDays = _shiftTemplate.NoOfEmployees * workingDays;
            var remaining = employeesAvailableWorkingDays - slots.Sum(x => x.Employees.Count);

            var basicSlots = slots.Count(x => x.IsBasicSlot());
            var extraEmployeesPerSlot = remaining / basicSlots;
            var remainder = remaining % basicSlots; //TODO

            int count = 0;
            foreach (var slot in slots)
            {
                if (!slot.IsBasicSlot())
                    continue;

               slot.AddEmptyEmployee(extraEmployeesPerSlot);
                if(count < 3)
                {
                    slot.AddEmptyEmployee(1);
                    count++;
                }
            }
        }
    }
}
