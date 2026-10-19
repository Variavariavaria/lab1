using LaboratorniEvsukov.Models;
using LaboratorniEvsukov.Parsing;
using LaboratorniEvsukov.Validation;
using System;
using System.CodeDom.Compiler;
using Xunit;

namespace LaboratorniEvsukov.Tests
{
    public class IncomeParserTests
    {
        private static readonly CurrencyCatalog Catalog = CurrencyCatalog.Default();

        [Fact]
        public void Testing_tests()
        {
            var lo = true;
            Assert.True(lo);
        }

        [Fact]
        public void Parse_Invalid()
        {
            var r = IncomeParser.Parse("01.1.2024 Зата домик", Catalog);
            Assert.False(r.Success);
        }

        [Fact]
        public void Parse_ValidPlain_ReturnsPlainIncome()
        {
            var r = IncomeParser.Parse("01.01.2024 Зарплата 50000", Catalog);
            Assert.True(r.Success);
            Assert.IsType<Income>(r.Value);
            Assert.Equal(50000, r.Value.Amount);
        }

        [Fact]
        public void Parse_WithCurrency_ReturnsInternational()
        {
            var r = IncomeParser.Parse("01.01.2024 Фриланс 100 Dollar", Catalog);
            Assert.True(r.Success);
            Assert.IsType<IncomeInternational>(r.Value);
        }

        [Fact]
        public void Parse_WithCountry_ReturnsBetweenCountries()
        {
            var r = IncomeParser.Parse("01.01.2024 Перевод 100 Germany", Catalog);
            Assert.True(r.Success);
            Assert.IsType<IncomeBetweenCountries>(r.Value);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("01.01.2024")]
        [InlineData("01.01.2024 Зарплата")]
        [InlineData("32.13.2024 Зарплата 100")]
        [InlineData("01.01.2024 Зарплата abc")]
        [InlineData("01.01.2024 Зарплата -5")]
        [InlineData("01.01.2024 Зарплата 0")]
        [InlineData("01.01.2024 Зарплата 100 Dollar Extra")]
        public void Parse_InvalidInput_ReturnsFailure(string raw)
        {
            var r = IncomeParser.Parse(raw, Catalog);
            Assert.False(r.Success);
            Assert.NotNull(r.Error);
        }
    }
}