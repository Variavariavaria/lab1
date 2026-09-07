using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorni_evsukov
{
    internal class income
    {
        public DateTime dateOfIncome;
        public string source;
        public int amount;
        public income(DateTime dateOfIncome, string source, int amount)
        {
            this.dateOfIncome = dateOfIncome;
            this.source = source;
            this.amount = amount;
        }
    }
}
