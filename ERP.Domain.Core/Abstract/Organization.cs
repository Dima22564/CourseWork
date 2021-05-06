using ERP.Domain.Core.Models;
using ERP.Domain.Core.Types;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Abstract
{
    public abstract class Organization : BaseEntity
    {
        [CanBeNull] public CompanyAddress Address { get; set; }
        [CanBeNull] public CompanyContacts Contacts { get; set; }
        public CompanyName Name { get; set; }
        
        public void AttachContacts(string phone, string email)
        {
            Contacts = new CompanyContacts(phone, email);
        }

        protected Organization(string fullName, string workName)
        {
            Name = new CompanyName(fullName, workName);
        }

        public Organization AttachContacts(CompanyContacts companyContacts)
        {
            Contacts = companyContacts;
            return this;
        }

        public void AttachAddress(string legal, string physical)
        {
            Address = new CompanyAddress(legal, physical);
        }
        
        public void AttachName(string workName, string fullNme)
        {
            Name = new CompanyName(fullNme, workName);
        }
        
        public void AttachAddress(CompanyAddress companyAddress)
        {
            Address = companyAddress;
        }

        protected Organization()
        {
        }
    }
}