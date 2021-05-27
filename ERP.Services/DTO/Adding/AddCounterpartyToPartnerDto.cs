using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace ERP.Services.DTO.Adding
{
    public class AddCounterpartyToPartnerDto
    {
        public long PartnerId { get; set; }
        public List<long> Counterparties { get; set; }
    }
}