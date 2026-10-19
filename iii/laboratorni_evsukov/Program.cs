using LaboratorniEvsukov.App;
using LaboratorniEvsukov.Storage;
using LaboratorniEvsukov.Ui;
using LaboratorniEvsukov.Validation;

namespace LaboratorniEvsukov
{
    internal static class Program
    {
        private static void Main()
        {
            var app = new IncomeApplication(
                new SystemConsole(),
                new IncomeRepository(),
                CurrencyCatalog.Default());
            app.Run();
        }
    }
}