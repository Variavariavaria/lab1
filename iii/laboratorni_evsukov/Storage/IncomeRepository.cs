using System.Collections.Generic;
using LaboratorniEvsukov.Models;

namespace LaboratorniEvsukov.Storage
{
    public sealed class IncomeRepository
    {
        private readonly List<Income> _items = new List<Income>();

        public IReadOnlyList<Income> All => _items;

        public void Add(Income income) => _items.Add(income);

        public int Count => _items.Count;
    }
}