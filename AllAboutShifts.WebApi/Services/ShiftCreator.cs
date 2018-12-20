using AllAboutShifts.WebApi.Common;
using AllAboutShifts.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Services
{
    public class ShiftCreator
    {
        private readonly ShiftTemplate _template;
        private readonly IEnumerable<Employee> _employees;
        private readonly EmployeeBalanceKeeper _balanceKeeper;

        public ShiftCreator(ShiftTemplate template, IEnumerable<Employee> employees)
        {
            _template = template;
            _employees = employees;

            _balanceKeeper = new EmployeeBalanceKeeper(_employees, _template);
        }

        public IEnumerable<ShiftSlot> Create(int month, int year)
        {
           var creator = new ShiftSlotCreator(_template, month, year);
           var slots = creator.Create();

            foreach (var slot in slots)
            {
                for (int i = 0; i < slot.Employees.Count; i++)
                {
                    slot.Employees[i] = _balanceKeeper.FetchEmployee(slot.Date, slot.ShiftName);
                }
            }

            return slots;
        }

    }
}
