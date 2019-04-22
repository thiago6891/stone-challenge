using ApplicationCore.Models;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IEmployeeBonusesCalculator
    {
        IEnumerable<Employee> CalculateEmployeeBonuses();
        bool IsPossibleToDistributeBonuses(IEnumerable<decimal> bonuses, decimal availableMoney);
    }
}