using System;
using Bogus;
using ERP.Domain.Core.Models;
using ERP.Test.FakeData;
using FluentAssertions;
using NUnit.Framework;

namespace ERP.Test.Domain.Models
{
    [TestFixture]
    public class CompanyTest : BaseTest
    {
        [Test]
        public void AttachAddressToCompany()
        {
            var company = CompanyFakeData.FakeCompany.Generate();
            var address = CompanyFakeData.FakeCompanyAddress.Generate();

            company.AttachAddress(address);
            
            Assert.NotNull(company.Address);
            Assert.AreSame(address, company.Address);
        }

        [Test]
        public void AttachContactsToCompany()
        {
            var company = CompanyFakeData.FakeCompany.Generate();
            var contacts = CompanyFakeData.FakeCompanyContacts.Generate();

            company.AttachContacts(contacts);
            
            Assert.NotNull(company.Contacts);
            Assert.AreSame(contacts, company.Contacts);
        }
        
        [Test]
        public void AttachInfoToCompany()
        {
            var company = CompanyFakeData.FakeCompany.Generate();
            var info = CompanyFakeData.FakeCompanyInfo.Generate();

            company.AttachInfo(info);
            
            Assert.NotNull(company.CompanyInfo);
            Assert.AreSame(info, company.CompanyInfo);
        }
    }
}