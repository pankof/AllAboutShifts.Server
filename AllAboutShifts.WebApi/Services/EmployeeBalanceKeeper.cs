using AllAboutShifts.WebApi.Common;
using AllAboutShifts.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Services
{
    public class EmployeeBalanceKeeper
    {
        public List<EmployeeBalance> Balances { get; set; } = new List<EmployeeBalance>();

        public EmployeeBalanceKeeper(IEnumerable<Employee> employees, ShiftTemplate template)
        {
            foreach (var employee in employees)
            {
                Balances.Add(new EmployeeBalance(employee, template.ShiftsHours));
            }
        }

        public Employee FetchEmployee(DateTime date, string shiftname)
        {
            foreach (var employee in Balances)
            {
                employee.CalculateRanking(date, shiftname);
            }

            var ordered = Balances.OrderByDescending(x => x.Ranking);
            var balance = ordered.FirstOrDefault();

            UpdateBalance(balance.Employee, date, shiftname);

            return balance.Employee;
        }

        private void UpdateBalance(Employee employee, DateTime date, string shiftname)
        {
            var balance = Balances.FirstOrDefault(x => x.Employee.Id == employee.Id);
            balance.AddWorkingDay(date, shiftname);
        }
    }
}
