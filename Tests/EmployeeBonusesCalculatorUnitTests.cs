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
        private readonly DateTime CURRENT_DATE = new DateTime(2019, 4, 20);

        private Mock<IDateTimeProvider> SetupDateTimeProvider(DateTime? now = null, float timeDiffInYears = 0.5f)
        {
            if (now == null)
                now = CURRENT_DATE;

            var stub = new Mock<IDateTimeProvider>();
            stub.Setup(dtp => dtp.Now).Returns(CURRENT_DATE);
            stub.Setup(dtp => dtp.CalculateTimeDifferenceInYears(CURRENT_DATE, CURRENT_DATE)).Returns(timeDiffInYears);
            return stub;
        }

        private Mock<IMinimumWageProvider> SetupMinimumWageProvider(decimal minimumWage = 998.00M)
        {
            var stub = new Mock<IMinimumWageProvider>();
            stub.Setup(mwp => mwp.MinimumWage).Returns(minimumWage);
            return stub;
        }

        private Mock<IEmployeesRepository> SetupEmployeeRepository(IEnumerable<Employee> employees = null)
        {
            if (employees == null)
                employees = new List<Employee>
                {
                    new Employee(9968, "Victor Wilson", Sector.Directors, "Diretor Financeiro", 12696.20M, new DateTime(2012, 1, 5), false),
                    new Employee(4468, "Flossie Wilson", Sector.Accounting, "Auxiliar de Contabilidade", 1396.52M, new DateTime(2015, 1, 5), false),
                    new Employee(8174, "Sherman Hodges", Sector.CustomerRelationship, "Líder de Relacionamento", 3899.74M, new DateTime(2015, 6, 7), false)
                };

            var stub = new Mock<IEmployeesRepository>();
            stub.Setup(er => er.GetEmployees()).Returns(employees);
            return stub;
        }

        [Fact]
        public void CalculateEmployeeBonuses_InvalidSector_ThrowsInvalidOperationException()
        {
            // Arrange
            var dateTimeProviderStub = SetupDateTimeProvider();
            var minimumWageProviderStub = SetupMinimumWageProvider();
            var employeesRepositoryStub = SetupEmployeeRepository(new List<Employee>()
            {
                new Employee(1, "Test", (Sector)6, "Job Title", 1000, new DateTime(2018, 10, 31), false)
            });

            var calculator = new EmployeeBonusesCalculator(
                dateTimeProviderStub.Object, 
                minimumWageProviderStub.Object, 
                employeesRepositoryStub.Object);

            // Act
            Action actual = () => calculator.CalculateEmployeeBonuses().Count();

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
            var dateTimeProviderStub = SetupDateTimeProvider();
            var minimumWageProviderStub = SetupMinimumWageProvider(1000.00M);
            var employeesRepositoryStub = SetupEmployeeRepository(new List<Employee>()
            {
                new Employee(1, "Test", Sector.Directors, "Job Title", salary, CURRENT_DATE, false)
            });

            var calculator = new EmployeeBonusesCalculator(
                dateTimeProviderStub.Object,
                minimumWageProviderStub.Object,
                employeesRepositoryStub.Object);

            // Act
            var employees = calculator.CalculateEmployeeBonuses();
            var actual = employees.First().Bonus;

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
            var dateTimeProviderStub = SetupDateTimeProvider();
            var minimumWageProviderStub = SetupMinimumWageProvider(1000.00M);
            var employeesRepositoryStub = SetupEmployeeRepository(new List<Employee>()
            {
                new Employee(1, "Test", sector, "Job Title", 1000.00M, CURRENT_DATE, false)
            });

            var calculator = new EmployeeBonusesCalculator(
                dateTimeProviderStub.Object,
                minimumWageProviderStub.Object,
                employeesRepositoryStub.Object);

            // Act
            var employees = calculator.CalculateEmployeeBonuses();
            var actual = employees.First().Bonus;

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
            var dateTimeProviderStub = SetupDateTimeProvider(timeDiffInYears: timeAtCompanyInYears);
            var minimumWageProviderStub = SetupMinimumWageProvider(1000.00M);
            var employeesRepositoryStub = SetupEmployeeRepository(new List<Employee>()
            {
                new Employee(1, "Test", Sector.Directors, "Job Title", 1000.00M, CURRENT_DATE, false)
            });

            var calculator = new EmployeeBonusesCalculator(
                dateTimeProviderStub.Object,
                minimumWageProviderStub.Object,
                employeesRepositoryStub.Object);

            // Act
            var employees = calculator.CalculateEmployeeBonuses();
            var actual = employees.First().Bonus;

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
            var dateTimeProviderStub = SetupDateTimeProvider();
            var minimumWageProviderStub = SetupMinimumWageProvider(1000.00M);
            var employeesRepositoryStub = SetupEmployeeRepository(new List<Employee>()
            {
                new Employee(1, "Test", Sector.Directors, "Job Title", salary, CURRENT_DATE, true)
            });

            var calculator = new EmployeeBonusesCalculator(
                dateTimeProviderStub.Object,
                minimumWageProviderStub.Object,
                employeesRepositoryStub.Object);

            // Act
            var employees = calculator.CalculateEmployeeBonuses();
            var actual = employees.First().Bonus;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(30, 30, 3, true)]
        [InlineData(31, 30, 3, true)]
        [InlineData(29, 30, 3, false)]
        public void IsPossibleToDistributeBonuses_ByDefault_ReturnIfTrueIfMoneyIsEnough(
            decimal totalMoneyAvailable, 
            decimal totalMoneyToDistribute, 
            int totalEmployees,
            bool expected)
        {
            // Arrange
            var dateTimeProviderStub = SetupDateTimeProvider();
            var minimumWageProviderStub = SetupMinimumWageProvider();
            var employeesRepositoryStub = SetupEmployeeRepository();

            var calculator = new EmployeeBonusesCalculator(
                dateTimeProviderStub.Object,
                minimumWageProviderStub.Object,
                employeesRepositoryStub.Object);

            var bonuses = new List<decimal>();
            for (int e = 0; e < totalEmployees; e++)
                bonuses.Add(totalMoneyToDistribute / totalEmployees);

            // Act
            var actual = calculator.IsPossibleToDistributeBonuses(bonuses, totalMoneyAvailable);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
