using ApplicationCore;
using ApplicationCore.Enumerations;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class EmployeeBonusesCalculatorUnitTests
    {
        [Fact]
        public void CalculateEmployeeBonuses_InvalidSector_ThrowsInvalidOperationException()
        {
            // Arrange
            var CURRENT_DATE = new DateTime(2019, 4, 20);

            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.Now)
                .Returns(CURRENT_DATE);
            dateTimeProviderStub.Setup(dtp => dtp.CalculateTimeDifferenceInYears(CURRENT_DATE, CURRENT_DATE))
                .Returns(0.5f);

            var minimumWageProviderStub = new Mock<IMinimumWageProvider>();
            minimumWageProviderStub.Setup(mwp => mwp.MinimumWage).Returns(998.00M);

            var calculator = new EmployeeBonusesCalculator(dateTimeProviderStub.Object, minimumWageProviderStub.Object);
            var employees = new List<Employee>()
            {
                new Employee(1, "Test", (Sector)6, "Job Title", 1000, new DateTime(2018, 10, 31), false)
            };

            // Act
            void actual() => calculator.CalculateEmployeeBonuses(employees).Count();

            // Assert
            Assert.Throws<InvalidOperationException>(actual);
        }

        [Theory]
        [InlineData(1000, 24000)]
        [InlineData(2000, 48000)]
        [InlineData(3000, 72000)]
        [InlineData(3000.01, 36000.12)]
        [InlineData(4000, 48000)]
        [InlineData(5000, 60000)]
        [InlineData(5000.01, 40000.08)]
        [InlineData(6000, 48000)]
        [InlineData(7000, 56000)]
        [InlineData(8000, 64000)]
        [InlineData(8000.01, 38400.048)]
        [InlineData(9000, 43200)]
        public void CalculateEmployeeBonuses_BySalary_ReturnsBonus(decimal salary, decimal expected)
        {
            // Arrange
            const decimal MINIMUM_WAGE = 1000.00M;
            var CURRENT_DATE = new DateTime(2019, 4, 20);
            var ADMISSION_DATE = new DateTime(2019, 4, 1);
            const Sector SECTOR = Sector.Directors;
            const bool IS_INTERN = false;

            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.Now)
                .Returns(CURRENT_DATE);
            dateTimeProviderStub.Setup(dtp => dtp.CalculateTimeDifferenceInYears(CURRENT_DATE, CURRENT_DATE))
                .Returns(0.5f);

            var minimumWageProviderStub = new Mock<IMinimumWageProvider>();
            minimumWageProviderStub.Setup(mwp => mwp.MinimumWage).Returns(MINIMUM_WAGE);

            var calculator = new EmployeeBonusesCalculator(dateTimeProviderStub.Object, minimumWageProviderStub.Object);
            var employees = new List<Employee>()
            {
                new Employee(1, "Test", SECTOR, "Job Title", salary, ADMISSION_DATE, IS_INTERN)
            };

            // Act
            var bonuses = calculator.CalculateEmployeeBonuses(employees);
            var actual = bonuses.First().Item2;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Sector.Directors, 24000)]
        [InlineData(Sector.Accounting, 36000)]
        [InlineData(Sector.Financial, 36000)]
        [InlineData(Sector.Technology, 36000)]
        [InlineData(Sector.GeneralServices, 48000)]
        [InlineData(Sector.CustomerRelationship, 72000)]
        public void CalculateEmployeeBonuses_BySector_ReturnsBonus(Sector sector, decimal expected)
        {
            // Arrange
            const decimal MINIMUM_WAGE = 1000.00M;
            var CURRENT_DATE = new DateTime(2019, 4, 20);
            var ADMISSION_DATE = new DateTime(2019, 4, 1);
            const decimal SALARY = 1000.00M;
            const bool IS_INTERN = false;

            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.Now)
                .Returns(CURRENT_DATE);
            dateTimeProviderStub.Setup(dtp => dtp.CalculateTimeDifferenceInYears(CURRENT_DATE, CURRENT_DATE))
                .Returns(0.5f);

            var minimumWageProviderStub = new Mock<IMinimumWageProvider>();
            minimumWageProviderStub.Setup(mwp => mwp.MinimumWage).Returns(MINIMUM_WAGE);

            var calculator = new EmployeeBonusesCalculator(dateTimeProviderStub.Object, minimumWageProviderStub.Object);
            var employees = new List<Employee>()
            {
                new Employee(1, "Test", sector, "Job Title", SALARY, ADMISSION_DATE, IS_INTERN)
            };

            // Act
            var bonuses = calculator.CalculateEmployeeBonuses(employees);
            var actual = bonuses.First().Item2;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 24000)]
        [InlineData(1.1, 36000)]
        [InlineData(3, 36000)]
        [InlineData(3.1, 48000)]
        [InlineData(8, 48000)]
        [InlineData(8.1, 72000)]
        public void CalculateEmployeeBonuses_ByTimeAtCompany_ReturnsBonus(float timeAtCompanyInYears, decimal expected)
        {
            // Arrange
            const decimal MINIMUM_WAGE = 1000.00M;
            var CURRENT_DATE = new DateTime(2019, 4, 20);
            const decimal SALARY = 1000.00M;
            const Sector SECTOR = Sector.Directors;
            const bool IS_INTERN = false;

            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.Now)
                .Returns(CURRENT_DATE);
            dateTimeProviderStub.Setup(dtp => dtp.CalculateTimeDifferenceInYears(CURRENT_DATE, CURRENT_DATE))
                .Returns(timeAtCompanyInYears);

            var minimumWageProviderStub = new Mock<IMinimumWageProvider>();
            minimumWageProviderStub.Setup(mwp => mwp.MinimumWage).Returns(MINIMUM_WAGE);

            var calculator = new EmployeeBonusesCalculator(dateTimeProviderStub.Object, minimumWageProviderStub.Object);
            var employees = new List<Employee>()
            {
                new Employee(1, "Test", SECTOR, "Job Title", SALARY, CURRENT_DATE, IS_INTERN)
            };

            // Act
            var bonuses = calculator.CalculateEmployeeBonuses(employees);
            var actual = bonuses.First().Item2;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000, 24000)]
        [InlineData(5000, 120000)]
        [InlineData(9000, 216000)]
        public void CalculateEmployeeBonuses_ByInternship_ReturnsBonus(decimal salary, decimal expected)
        {
            // Arrange
            const decimal MINIMUM_WAGE = 1000.00M;
            var CURRENT_DATE = new DateTime(2019, 4, 20);
            var ADMISSION_DATE = new DateTime(2019, 4, 1);
            const Sector SECTOR = Sector.Directors;
            const bool IS_INTERN = true;

            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.Now)
                .Returns(CURRENT_DATE);
            dateTimeProviderStub.Setup(dtp => dtp.CalculateTimeDifferenceInYears(CURRENT_DATE, CURRENT_DATE))
                .Returns(0.5f);

            var minimumWageProviderStub = new Mock<IMinimumWageProvider>();
            minimumWageProviderStub.Setup(mwp => mwp.MinimumWage).Returns(MINIMUM_WAGE);

            var calculator = new EmployeeBonusesCalculator(dateTimeProviderStub.Object, minimumWageProviderStub.Object);
            var employees = new List<Employee>()
            {
                new Employee(1, "Test", SECTOR, "Job Title", salary, ADMISSION_DATE, IS_INTERN)
            };

            // Act
            var bonuses = calculator.CalculateEmployeeBonuses(employees);
            var actual = bonuses.First().Item2;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}