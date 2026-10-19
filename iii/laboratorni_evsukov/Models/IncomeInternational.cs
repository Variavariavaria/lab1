using System;

namespace LaboratorniEvsukov.Models
{
    public class IncomeInternational : Income
    {
        public string Currency { get; }

        public IncomeInternational(DateTime date, string source, int amount, string currency)
            : base(date, source, amount)
        {
            Currency = currency;
        }

        public override string ToString() =>
            base.ToString() + $" | Валюта: {Currency}";
    }
}