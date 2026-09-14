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
            do
            {
                ConsoleGreeting();
                menuNavigate(Console.ReadLine());
            }
            while (true);
        }
        private static void ConsoleGreeting()
        {
            Console.Clear();
            Console.WriteLine("1. Проверить список записей о доходах");
            Console.WriteLine("2. Добавить новую запись");
        }

        private static void addIncomeData()
        {
            Console.Clear();
            Console.WriteLine("Создайте запись форматом: ДД.ММ.ГГГГ  Источник_Денег  Целый_Размер_Пополнения");
            string rawdata = Console.ReadLine();
            char[] bruh = { ' ' };
            string[] mediumData = rawdata.Split(bruh, StringSplitOptions.RemoveEmptyEntries);
            DateTime cookedDate = DateTime.Parse(mediumData[0]);
            string sorc = mediumData[1];
            int amout = int.Parse(mediumData[2]);
            Income boo = new Income(cookedDate, sorc, amout);
            Income.AllIncomes.Add(boo);
            Console.WriteLine("Добавлено!");
            Console.ReadKey();
        }

        private static void ShowData()
        {
            Console.Clear();
            List<string> stuffs = Income.Incomes_StringData();
            foreach (string stuff in stuffs)
            {
                Console.WriteLine(stuff);
            }
            Console.ReadKey();
        }
        private static void menuNavigate(string take)
        {
            switch (take)
            {
                case "1":
                    {
                        ShowData();
                        break;
                    }
                case "2":
                    {
                        addIncomeData();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
