using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace ERP.Domain.Core.Types
{
    [Owned]
    public class CompanyAddress
    {
        [Column("LegalAddress")]
        [CanBeNull] public string LegalAddress { get; set; }
        
        [Column("PhysicalAddress")]
        [CanBeNull] public string PhysicalAddress { get; set; }

        public CompanyAddress(string legalAddress, string physicalAddress)
        {
            LegalAddress = legalAddress;
            PhysicalAddress = physicalAddress;
        }

        public CompanyAddress()
        {
        }
        
        
    }
}