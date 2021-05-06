using Bogus;
using ERP.Test.FakeData;
using NUnit.Framework;

namespace ERP.Test.Domain
{
    public abstract class BaseTest
    {
        protected Faker Faker { get; private set; }
        protected CompanyFakeData CompanyFakeData { get; private set; }

        [SetUp]
        public void SetupBeforeEachTest()
        {
            const int seed = 2489; 
            Faker = new Faker();
            CompanyFakeData = new CompanyFakeData(seed);
        }
    }
}