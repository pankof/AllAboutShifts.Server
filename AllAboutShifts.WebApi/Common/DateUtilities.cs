﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutShifts.WebApi.Common
{
    public static class DateUtilities
    {
        public static IEnumerable<DateTime> AllDatesInMonth(int month, int year)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
    }
}
