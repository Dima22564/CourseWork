using System;
using System.Collections.Generic;
using ERP.Services.DTO.Types;

namespace ERP.Services.DTO.Return
{
    public class CounterpartyToReturn
    {
        public CompanyNameToReturn Name { get; set; }
        public string Crtr { get; set; }
        public long Tin { get; set; }
        public DateTime CreatedAt { get; set; }
        public CompanyContactsToReturn Contacts { get; set; }
        public CompanyAddressToReturn Address { get; set; }
        public ICollection<BankAccountToReturn> BankAccounts { get; set; }
    }
}