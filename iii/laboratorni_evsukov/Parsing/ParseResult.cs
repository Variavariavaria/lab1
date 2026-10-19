using LaboratorniEvsukov.Models;

namespace LaboratorniEvsukov.Parsing
{
    public sealed class ParseResult
    {
        public bool Success { get; }
        public Income Value { get; }
        public string Error { get; }

        private ParseResult(bool success, Income value, string error)
        {
            Success = success;
            Value = value;
            Error = error;
        }

        public static ParseResult Ok(Income income) =>
            new ParseResult(true, income, null);

        public static ParseResult Fail(string error) =>
            new ParseResult(false, null, error);
    }
}