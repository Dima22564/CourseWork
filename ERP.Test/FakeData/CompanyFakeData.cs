using Bogus;
using ERP.Domain.Core.Models;
using ERP.Domain.Core.Types;

namespace ERP.Test.FakeData
{
    public class CompanyFakeData : Fake
    {

        public CompanyFakeData(int seed) : base(seed)
        {
        }
        
        public Faker<Company> FakeCompany { get; set; } = new Faker<Company>()
            .CustomInstantiator(f => Company.Create(
                f.Random.Int(12).ToString(),
                f.Company.CompanySuffix(),
                f.Company.CompanyName(),
                f.Company.CompanyName(),
                f.Company.CompanyName()
                ));

        public Faker<CompanyAddress> FakeCompanyAddress { get; set; } = new Faker<CompanyAddress>();
        public Faker<CompanyContacts> FakeCompanyContacts { get; set; } = new Faker<CompanyContacts>();
        public Faker<CompanyInfo> FakeCompanyInfo { get; set; } = new Faker<CompanyInfo>();
        public Faker<CompanyName> FakeCompanyName { get; set; } = new Faker<CompanyName>();


    }
}