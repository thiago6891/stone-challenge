using ApplicationCore.Interfaces;

namespace WebAPI.Utils
{
    public class MinimumWageProvider : IMinimumWageProvider
    {
        // TODO: decide where to put this information
        public decimal MinimumWage => 998.00M;
    }
}