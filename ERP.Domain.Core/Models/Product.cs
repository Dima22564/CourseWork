using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Enums;
using ERP.Domain.Core.Intermediary;

namespace ERP.Domain.Core.Models
{
    public class Product : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Code { get; set; }
        public string WorkName { get; set; }
        public string FullName { get; set; }
        public int Vat { get; set; }
        public float Price { get; set; }
        public int Quantity{ get; set; }
        public virtual ICollection<ClientOrderProduct> ClientOrderProducts { get; set; }
        public virtual ICollection<BusinessProposalProduct> BusinessProposalProducts { get; set; }
    }
}