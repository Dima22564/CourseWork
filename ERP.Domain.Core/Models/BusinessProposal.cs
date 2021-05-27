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
        public DocumentStatuses Status { get; set; } = DocumentStatuses.NotApproved;
        public virtual ICollection<BusinessProposalProduct> BusinessProposalProducts { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }
        public virtual Partner Partner { get; set; }
        public long PartnerId { get; set; }

        public void Approve()
        {
            Status = DocumentStatuses.Approved;
        }

        public void Reject()
        {
            Status = DocumentStatuses.Rejected;
        }

        public void Close()
        {
            Status = DocumentStatuses.NotValid;
        }

        public bool IsValid()
        {
            return Status == DocumentStatuses.Valid;
        }
        
        public bool IsApprove()
        {
            return Status == DocumentStatuses.Approved;
        }
    }
}