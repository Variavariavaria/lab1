namespace LaboratorniEvsukov.Ui
{
    public interface IConsole
    {
        void Clear();
        void WriteLine(string text);
        string ReadLine();
        void ReadKey();
    }
}