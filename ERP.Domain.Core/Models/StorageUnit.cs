using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Enums;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class StorageUnit : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StorageUnitId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        [CanBeNull] public string FullName { get; set; }
        [CanBeNull] public string InternationalAbbreviation { get; set; }
        public MeasuredValueTypes MeasuredValueType { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}