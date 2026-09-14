using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorni_evsukov
{
    public class Income
    {
        public static List<Income> AllIncomes = new List<Income> { };
        public static List<string> Incomes_StringData()
        {
            List<string> something = new List<string>();
            foreach (Income stuff in AllIncomes)
            {
                something.Add(stuff.ToString());
            }
            return something;
        }

        public DateTime dateOfIncome;
        public string source;
        public int amount;
        public Income(DateTime dateOfIncome, string source, int amount)
        {
            this.dateOfIncome = dateOfIncome;
            this.source = source;
            this.amount = amount;
        }
        public override string ToString()
        {
           return $"Дата: {dateOfIncome.Date} | Источник: {source} | Размер: {amount}";
        }    
    }
}
