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
        public Vat Vat { get; set; }
        public int StorageUnitId { get; set; }
        public virtual StorageUnit StorageUnit { get; set; }
        public virtual ICollection<TypeProduct> TypeProducts { get; set; }
        public virtual ICollection<ClientOrderProduct> ClientOrderProducts { get; set; }
        public virtual ICollection<BusinessProposalProduct> BusinessProposalProducts { get; set; }
    }
}