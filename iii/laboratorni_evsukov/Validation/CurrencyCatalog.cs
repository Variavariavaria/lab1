using System.Collections.Generic;
using System.Linq;

namespace LaboratorniEvsukov.Validation
{
    public sealed class CurrencyCatalog
    {
        private readonly HashSet<string> _currencies;

        public CurrencyCatalog(IEnumerable<string> currencies)
        {
            _currencies = new HashSet<string>(currencies);
        }

        public static CurrencyCatalog Default() =>
            new CurrencyCatalog(new[] { "Rouble", "Tenge", "Dollar", "Euro" });

        public bool Contains(string value) => _currencies.Contains(value);

        public IReadOnlyList<string> All => _currencies.ToList();
    }
}