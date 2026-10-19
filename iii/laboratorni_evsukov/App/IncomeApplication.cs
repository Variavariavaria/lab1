using LaboratorniEvsukov.Parsing;
using LaboratorniEvsukov.Storage;
using LaboratorniEvsukov.Ui;
using LaboratorniEvsukov.Validation;

namespace LaboratorniEvsukov.App
{
    public sealed class IncomeApplication
    {
        private readonly IConsole _console;
        private readonly MenuRenderer _menu;
        private readonly IncomeRepository _repository;
        private readonly CurrencyCatalog _catalog;

        public IncomeApplication(IConsole console, IncomeRepository repository,
            CurrencyCatalog catalog)
        {
            _console = console;
            _repository = repository;
            _catalog = catalog;
            _menu = new MenuRenderer(console);
        }

        public void Run()
        {
            while (true)
            {
                _menu.ShowMainMenu();
                if (!HandleMenu(_console.ReadLine())) return;
            }
        }

        private bool HandleMenu(string choice)
        {
            switch (choice)
            {
                case "1": ShowAll(); return true;
                case "2": AddIncome(); return true;
                case "0": return false;
                default: return true;
            }
        }

        public void ShowAll()
        {
            _console.Clear();
            if (_repository.Count == 0)
                _console.WriteLine("Записей нет.");
            foreach (var income in _repository.All)
                _console.WriteLine(income.ToString());
            _menu.Pause();
        }

        public bool AddIncome()
        {
            _menu.ShowAddHint();
            var raw = _console.ReadLine();
            var result = IncomeParser.Parse(raw, _catalog);
            if (!result.Success)
            {
                _menu.ShowError(result.Error);
                _menu.Pause();
                return false;
            }
            _repository.Add(result.Value);
            _menu.ShowSuccess();
            _menu.Pause();
            return true;
        }
    }
}