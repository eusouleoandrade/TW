using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TW.HotelReservation.Service
{
    public static class DateCommonService
    {
        public static bool IsWeekend(this DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday);
        }

        public static bool IsDateTime(this string date, out DateTime outDate)
        {
            return DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate);
        }

        public static List<DateTime> GetPeriod(DateTime starDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();

            while (starDate <= endDate)
            {
                dates.Add(starDate);
                starDate = starDate.AddDays(1);
            }

            return dates;
        }
    }
}
