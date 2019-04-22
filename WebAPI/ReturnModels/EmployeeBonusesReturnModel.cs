using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPI.ReturnModels
{
    public class EmployeeBonusesReturnModel
    {
        [JsonProperty(PropertyName = "participacoes")]
        public IEnumerable<EmployeeBonus> Bonuses { get; }
        [JsonProperty(PropertyName = "total_de_funcionarios")]
        public int TotalEmployees { get; }
        [JsonProperty(PropertyName = "total_distribuido")]
        public decimal TotalDistributed { get; }
        [JsonProperty(PropertyName = "total_disponibilizado")]
        public decimal TotalMadeAvailable { get; }
        [JsonProperty(PropertyName = "saldo_total_disponibilizado")]
        public decimal BalanceAfterDistribution { get; }

        public EmployeeBonusesReturnModel(
            IEnumerable<EmployeeBonus> bonuses,
            int totalEmployees,
            decimal totalDistributed,
            decimal totalMadeAvailable,
            decimal balanceAfterDistribution)
        {
            Bonuses = bonuses;
            TotalEmployees = totalEmployees;
            TotalDistributed = totalDistributed;
            TotalMadeAvailable = totalMadeAvailable;
            BalanceAfterDistribution = balanceAfterDistribution;
        }
    }

    public class EmployeeBonus
    {
        [JsonProperty(PropertyName = "matricula")]
        public string RegistrationNumber { get; }
        [JsonProperty(PropertyName = "nome")]
        public string Name { get; }
        [JsonProperty(PropertyName = "valor_da_participacao")]
        public decimal Bonus { get; }

        public EmployeeBonus(string registrationNumber, string name, decimal bonus)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            Bonus = bonus;
        }
    }
}