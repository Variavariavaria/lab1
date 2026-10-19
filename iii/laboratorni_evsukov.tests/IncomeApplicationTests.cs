using System.Collections.Generic;
using LaboratorniEvsukov.App;
using LaboratorniEvsukov.Storage;
using LaboratorniEvsukov.Ui;
using LaboratorniEvsukov.Validation;
using Xunit;

namespace LaboratorniEvsukov.Tests
{
    internal sealed class FakeConsole : IConsole
    {
        private readonly Queue<string> _inputs;
        public List<string> Output { get; } = new List<string>();
        public FakeConsole(params string[] inputs) => _inputs = new Queue<string>(inputs);
        public void Clear() { }
        public void WriteLine(string text) => Output.Add(text);
        public string ReadLine() => _inputs.Count > 0 ? _inputs.Dequeue() : "0";
        public void ReadKey() { }
    }

    public class IncomeApplicationTests
    {
        [Fact]
        public void AddIncome_Valid_SavesRecord()
        {
            var console = new FakeConsole("01.01.2024 Зарплата 100");
            var repo = new IncomeRepository();
            var app = new IncomeApplication(console, repo, CurrencyCatalog.Default());

            Assert.True(app.AddIncome());
            Assert.Equal(1, repo.Count);
        }

        [Fact]
        public void AddIncome_Invalid_DoesNotSave()
        {
            var console = new FakeConsole("мусор");
            var repo = new IncomeRepository();
            var app = new IncomeApplication(console, repo, CurrencyCatalog.Default());

            Assert.False(app.AddIncome());
            Assert.Equal(0, repo.Count);
        }
    }
}