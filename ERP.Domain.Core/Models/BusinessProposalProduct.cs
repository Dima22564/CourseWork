using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Enums;

namespace ERP.Domain.Core.Models
{
    public class BusinessProposalProduct : BaseEntity, IDocumentProduct
    {
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public int PositionNumber { get; set; }
        public float Sale { get; set; } = 0;
        
        public string BusinessProposalId { get; set; }
        public virtual BusinessProposal BusinessProposal { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}