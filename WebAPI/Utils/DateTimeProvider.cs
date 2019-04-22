using ApplicationCore.Interfaces;
using System;

namespace WebAPI.Utils
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;

        public float CalculateTimeDifferenceInYears(DateTime a, DateTime b)
        {
            var comp = a.CompareTo(b);

            if (comp == 0)
                return 0;

            var earlier = comp < 0 ? a : b;
            var later = comp < 0 ? b : a;

            var diff = new DateTime((later - earlier).Ticks);

            // Since DateTime.MinValue is 1/1/1, we have to subtract 1 to get the right calculation.
            var years = diff.Year - 1;
            var days = diff.DayOfYear - 1;

            // We can use 365 or 366 days in a year. The aprroximation is good enough for our purposes.
            const int DAYS_IN_YEAR = 365;
            return years + days / DAYS_IN_YEAR;
        }
    }
}
