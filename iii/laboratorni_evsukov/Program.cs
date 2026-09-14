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
                                Console.WriteLine("Создайте запись форматом: ДД.ММ.ГГГГ  Источник_Денег  Целый_Размер_Пополнения");
                                string rawdata = Console.ReadLine();
                                char[] bruh = { ' ' };
                                string[] mediumData = rawdata.Split(bruh, StringSplitOptions.RemoveEmptyEntries);
                                DateTime cookedDate = DateTime.Parse(mediumData[0]);
                                string sorc = mediumData[1];
                                int amout = int.Parse(mediumData[2]);
                                income boo = new income(cookedDate, sorc, amout);
                                incomes.Add(boo);
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
            while (true);
        }
    }
}
