namespace LaboratorniEvsukov.Ui
{
    public sealed class MenuRenderer
    {
        private readonly IConsole _console;

        public MenuRenderer(IConsole console) => _console = console;

        public void ShowMainMenu()
        {
            _console.Clear();
            _console.WriteLine("1. Проверить список записей о доходах");
            _console.WriteLine("2. Добавить новую запись");
            _console.WriteLine("0. Выход");
        }

        public void ShowAddHint()
        {
            _console.Clear();
            _console.WriteLine("Формат: ДД.ММ.ГГГГ Источник Сумма [Валюта|Страна]");
            _console.WriteLine("Пример: 01.01.2024 Зарплата 50000 Dollar");
        }

        public void ShowError(string error) => _console.WriteLine($"Ошибка: {error}");

        public void ShowSuccess() => _console.WriteLine("Добавлено!");

        public void Pause() => _console.ReadKey();
    }
}