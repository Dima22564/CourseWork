using Bogus;
using ERP.Domain.Core.Models;

namespace ERP.Test.FakeData
{
    public class CountryFakeData : Fake
    {
        public CountryFakeData(int seed) : base(seed)
        {
        }
        
        public Faker<Country> FakeCountry { get; set; } = new Faker<Country>()
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.Code2, f => f.Lorem.Letter(2).ToUpper())
            .RuleFor(x => x.Code3, f => f.Lorem.Letter(2).ToUpper())
            .RuleFor(x => x.FullName, f => f.Lorem.Word());
    }
}