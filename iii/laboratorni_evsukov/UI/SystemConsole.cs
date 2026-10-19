using System;

namespace LaboratorniEvsukov.Ui
{
    public sealed class SystemConsole : IConsole
    {
        public void Clear() => Console.Clear();
        public void WriteLine(string text) => Console.WriteLine(text);
        public string ReadLine() => Console.ReadLine();
        public void ReadKey() => Console.ReadKey(true);
    }
}