using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}