using AllAboutShifts.WebApi.Entities;
using AllAboutShifts.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        public ShiftController()
        {

        }

        [HttpPost]
        public ActionResult<IEnumerable<string>> Post()
        {
            var template = new ShiftTemplate();
            template.ShiftsHours = new List<ShiftHour>()
            {
                new ShiftHour() { Name = "7:00 - 15:00", NoOfEmployeesWeekDays = 3, NoOfEmployeesWeekend = 1 },
                new ShiftHour() { Name = "15:00 - 23:00", NoOfEmployeesWeekDays = 1, NoOfEmployeesWeekend = 1 },
                new ShiftHour() { Name = "23:00 - 7:00", NoOfEmployeesWeekDays = 1, NoOfEmployeesWeekend = 1 },
            };

            template.BasicShift = "7:00 - 15:00";
            template.NoOfEmployees = 9;

            var employees = new List<Employee>()
            {
                new Employee() { Id = 1 },
                new Employee() { Id = 2 },
                new Employee() { Id = 3 },
                new Employee() { Id = 4 },
                new Employee() { Id = 5 },
                new Employee() { Id = 6 },
                new Employee() { Id = 7 },
                new Employee() { Id = 8 },
                new Employee() { Id = 9 }
            };

            var creator = new ShiftCreator(template, employees);
            var result = creator.Create(12, 2018);

            return Ok();
        }

    }
}
