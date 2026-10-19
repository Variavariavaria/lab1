using System;
using System.Globalization;
using LaboratorniEvsukov.Models;
using LaboratorniEvsukov.Validation;

namespace LaboratorniEvsukov.Parsing
{
    public static class IncomeParser
    {
        private const string DateFormat = "dd.MM.yyyy";

        public static ParseResult Parse(string raw, CurrencyCatalog catalog)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return ParseResult.Fail("Пустая строка.");
            var parts = raw.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return ValidatePartsCount(parts) ?? ParseParts(parts, catalog);
        }

        private static ParseResult ValidatePartsCount(string[] parts)
        {
            if (parts.Length < 3 || parts.Length > 4)
                return ParseResult.Fail("Ожидается 3 или 4 поля.");
            return null;
        }

        private static ParseResult ParseParts(string[] parts, CurrencyCatalog catalog)
        {
            if (!DateTime.TryParseExact(parts[0], DateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                return ParseResult.Fail("Неверный формат даты (ожидается ДД.ММ.ГГГГ).");

            string source = parts[1];
            if (!InputValidator.IsValidSource(source))
                return ParseResult.Fail("Источник должен быть непустым.");

            if (!int.TryParse(parts[2], out var amount) || amount <= 0)
                return ParseResult.Fail("Сумма должна быть целым положительным числом.");

            return parts.Length == 4
                ? BuildWithExtra(date, source, amount, parts[3], catalog)
                : ParseResult.Ok(new Income(date, source, amount));
        }

        private static ParseResult BuildWithExtra(
            DateTime date, string source, int amount, string extra, CurrencyCatalog catalog)
        {
            if (!InputValidator.IsValidSource(extra))
                return ParseResult.Fail("Дополнительный параметр не должен быть пустым.");
            return catalog.Contains(extra)
                ? ParseResult.Ok(new IncomeInternational(date, source, amount, extra))
                : ParseResult.Ok(new IncomeBetweenCountries(date, source, amount, extra));
        }
    }
}