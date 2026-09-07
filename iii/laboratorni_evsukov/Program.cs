using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorni_evsukov
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool shit = true;
        List<income> incomes = new List<income>();
        void TTTell(income income)
        {
            Console.WriteLine($"\nДата: {income.dateOfIncome}");
            Console.WriteLine($"Источник: {income.source}");
            Console.WriteLine($"Размер: {income.amount}");
        }
            do
            {
                Console.Clear();
                Console.WriteLine("1. Проверить список записей о доходах");
                Console.WriteLine("2. Добавить новую записьф");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            try
                            {
                                foreach (income item in incomes)
                                {
                                    TTTell(item);
                                    Console.ReadLine();
                                }
                            }
                            catch { break; }
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("Напишите дату в формате ДД.ММ.ГГГГ:");
                                string rawDate = Console.ReadLine();
                                DateTime cookedDate = DateTime.Parse(rawDate);

                                Console.WriteLine("Напишите, откуда эти деньги пришли:");
                                string sorc = Console.ReadLine();

                                Console.WriteLine("Напишите количество рублей (целое число):");
                                string rawSize = Console.ReadLine();
                                int amout = int.Parse(rawSize);

                                income bruh = new income(cookedDate, sorc, amout);
                                incomes.Add(bruh);
                            }
                            catch { break; }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            } 
            while (shit == true);
        }
    }
}
