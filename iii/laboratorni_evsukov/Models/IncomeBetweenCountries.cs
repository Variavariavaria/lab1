using System;

namespace LaboratorniEvsukov.Models
{
    public class IncomeBetweenCountries : Income
    {
        public string Country { get; }

        public IncomeBetweenCountries(DateTime date, string source, int amount, string country)
            : base(date, source, amount)
        {
            Country = country;
        }

        public override string ToString() =>
            base.ToString() + $" | Из страны: {Country}";
    }
}