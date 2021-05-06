using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Enums;

namespace ERP.Domain.Core.Models
{
    [Table("BusinessProposals")]
    public class BusinessProposal : Document
    {
        public DocumentStatuses Status { get; set; }
        
        public virtual ICollection<BusinessProposalProduct> BusinessProposalProducts { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
    }
}