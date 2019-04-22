using ApplicationCore.Enumerations;
using System;

namespace ApplicationCore.Models
{
    public class Employee
    {
        public int RegistrationNumber { get; }
        public string Name { get; }
        public Sector Sector { get; }
        public string JobTitle { get; }
        public decimal GrossSalary { get; }
        public DateTime AdmissionDate { get; }
        public bool IsIntern { get; }

        public decimal Bonus { get; set; }

        public Employee(
            int registrationNumber,
            string name,
            Sector sector,
            string jobTitle,
            decimal grossSalary,
            DateTime admissionDate,
            bool isIntern)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            Sector = sector;
            IsIntern = isIntern;
            JobTitle = IsIntern ? "Estagiário" : jobTitle;
            GrossSalary = grossSalary;
            AdmissionDate = admissionDate;
        }
    }
}