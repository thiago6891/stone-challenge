using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly DefaultContext _db;

        public EmployeesRepository(DefaultContext db)
        {
            _db = db;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.Employees.ToList();
        }
    }
}