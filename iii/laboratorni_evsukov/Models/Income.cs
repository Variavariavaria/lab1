using System;

namespace LaboratorniEvsukov.Models
{
    public class Income
    {
        public DateTime Date { get; }
        public string Source { get; }
        public int Amount { get; }

        public Income(DateTime date, string source, int amount)
        {
            Date = date;
            Source = source;
            Amount = amount;
        }

        public override string ToString() =>
            $"Дата: {Date:dd.MM.yyyy} | Источник: {Source} | Размер: {Amount}";
    }
}