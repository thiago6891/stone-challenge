using ApplicationCore.Enumerations;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public IEnumerable<Employee> GetEmployees()
        {
            // TODO: replace this with real code
            var employees = new List<Employee>
            {
                new Employee(9968, "Victor Wilson", Sector.Directors, "Diretor Financeiro", 12696.20M, new DateTime(2012, 1, 5), false),
                new Employee(4468, "Flossie Wilson", Sector.Accounting, "Auxiliar de Contabilidade", 1396.52M, new DateTime(2015, 1, 5), false),
                new Employee(8174, "Sherman Hodges", Sector.CustomerRelationship, "Líder de Relacionamento", 3899.74M, new DateTime(2015, 6, 7), false)
            };

            return employees;
        }
    }
}