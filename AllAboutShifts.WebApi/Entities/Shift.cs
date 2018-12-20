using System;

namespace AllAboutShifts.WebApi.Entities
{
    public class Shift
    {
        public Shift(DateTime date, string name)
        {
            Name = name;
            Date = date;
        }
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}