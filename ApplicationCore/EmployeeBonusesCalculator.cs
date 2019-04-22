using ApplicationCore.Enumerations;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore
{
    public class EmployeeBonusesCalculator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMinimumWageProvider _minimumWageProvider;

        public EmployeeBonusesCalculator(IDateTimeProvider dateTimeProvider, IMinimumWageProvider minimumWageProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _minimumWageProvider = minimumWageProvider;
        }

        public IEnumerable<Tuple<Employee, decimal>> CalculateEmployeeBonuses(IEnumerable<Employee> employees)
        {
            return employees.Select(e => new Tuple<Employee, decimal>(
                e, CalculateBonus(e.GrossSalary, e.Sector, e.AdmissionDate, e.IsIntern)));
        }

        private decimal CalculateBonus(decimal grossSalary, Sector sector, DateTime admissionDate, bool isIntern)
        {
            const int MONTHS_IN_YEAR = 12;

            var admissionTimeWeight = CalculateAdmissionTimeWeight(admissionDate);
            var sectorWeight = CalculateSectorWeight(sector);
            var salaryWeight = CalculateSalaryWeight(grossSalary, isIntern);

            return MONTHS_IN_YEAR * (grossSalary * (admissionTimeWeight + sectorWeight)) / salaryWeight;
        }

        private int CalculateAdmissionTimeWeight(DateTime admissionDate)
        {
            var timeAtCompanyInYears = _dateTimeProvider
                .CalculateTimeDifferenceInYears(_dateTimeProvider.Now, admissionDate);

            if (timeAtCompanyInYears <= 1)
                return 1;

            if (timeAtCompanyInYears <= 3)
                return 2;

            if (timeAtCompanyInYears <= 8)
                return 3;

            return 5;
        }

        private int CalculateSectorWeight(Sector sector)
        {
            switch (sector)
            {
                case Sector.Directors:
                    return 1;
                case Sector.Accounting:
                case Sector.Financial:
                case Sector.Technology:
                    return 2;
                case Sector.GeneralServices:
                    return 3;
                case Sector.CustomerRelationship:
                    return 5;
                default:
                    throw new InvalidOperationException("Invalid Company Sector.");
            }
        }

        private int CalculateSalaryWeight(decimal grossSalary, bool isIntern)
        {
            if (grossSalary <= 3 * _minimumWageProvider.MinimumWage || isIntern)
                return 1;

            if (grossSalary <= 5 * _minimumWageProvider.MinimumWage)
                return 2;

            if (grossSalary <= 8 * _minimumWageProvider.MinimumWage)
                return 3;

            return 5;
        }
    }
}