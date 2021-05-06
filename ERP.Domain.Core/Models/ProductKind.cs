using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Enums;
using ERP.Domain.Core.Intermediary;

namespace ERP.Domain.Core.Models
{
    public class ProductKind : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        public ProductType ProductType { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Vat Vat { get; set; }

        public virtual ICollection<TypeProduct> TypeProducts { get; set; }
    }
}