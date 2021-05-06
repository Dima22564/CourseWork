using Bogus;
using ERP.Domain.Core.Models;

namespace ERP.Test.FakeData
{
    public class PositionFakeData : Fake
    {
        public PositionFakeData(int seed) : base(seed)
        {
        }
        
        public Faker<Position> FakePosition { get; set; } = new Faker<Position>()
            .RuleFor(x => x.Description, f => f.Lorem.Paragraph(1))
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.IncludeAt, f => f.Date.Past())
            .RuleFor(x => x.ExcludeAt, f => null);
    }
}