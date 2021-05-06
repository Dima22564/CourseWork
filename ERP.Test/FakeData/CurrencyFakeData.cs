using Bogus;
using ERP.Domain.Core.Models;

namespace ERP.Test.FakeData
{
    public class CurrencyFakeData : Fake
    {
        public CurrencyFakeData(int seed) : base(seed)
        {
        }
        
        public Faker<Currency> FakeCurrency { get; set; } = new Faker<Currency>()
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.CharacterCode, f => f.Lorem.Word().ToUpper())
            .RuleFor(x => x.ExchangeRate, f => f.Random.Float())
            .RuleFor(x => x.NumericCode, f => f.Random.Int(1, 999));
    }
}