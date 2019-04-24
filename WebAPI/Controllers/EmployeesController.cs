using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.ReturnModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeBonusesCalculator _employeeBonusesCalculator;

        public EmployeesController(IEmployeeBonusesCalculator employeeBonusesCalculator)
        {
            _employeeBonusesCalculator = employeeBonusesCalculator;
        }

        [HttpGet]
        [Route("bonuses/{availableMoney}")]
        public ActionResult<dynamic> Get(decimal availableMoney)
        {
            var employees = _employeeBonusesCalculator.CalculateEmployeeBonuses();

            if (_employeeBonusesCalculator.IsPossibleToDistributeBonuses(employees.Select(e => e.Bonus), availableMoney))
            {
                var result = new EmployeeBonusesReturnModel(
                    employees.Select(e => new EmployeeBonus(e.RegistrationNumber.ToString("D7"), e.Name, e.Bonus)),
                    employees.Count(),
                    employees.Sum(e => e.Bonus),
                    availableMoney,
                    availableMoney - employees.Sum(e => e.Bonus));
                return Ok(result);
            }
            
            return BadRequest("Não foi possível distribuir os lucros com o volume disponibilizado.");
        }
    }
}