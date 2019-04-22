using ApplicationCore.Interfaces;

namespace WebAPI.Utils
{
    public class MinimumWageProvider : IMinimumWageProvider
    {
        private const decimal MINIMUM_WAGE = 998.00M;
        
        public decimal MinimumWage => MINIMUM_WAGE;
    }
}