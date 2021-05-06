using System;
using ERP.Services.DTO.Types;

namespace ERP.Services.DTO.Return
{
    public class PartnerToReturnDto
    {
        public long PartnerId { get; set; }
        public CompanyNameToReturn Name { get; set; }
        public string Relation { get; set; }
        public string Prefix { get; set; }
        public DateTime CreatedAt { get; set; }
        public CompanyContactsToReturn Contacts { get; set; }
        public CompanyAddressToReturn Address { get; set; }
    }
}