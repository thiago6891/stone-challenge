using System;

namespace ApplicationCore.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        float CalculateTimeDifferenceInYears(DateTime a, DateTime b);
    }
}