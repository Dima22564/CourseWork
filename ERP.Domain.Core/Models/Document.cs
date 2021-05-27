using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    [Table("Documents")]
    public class Document : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Number { get; set; }
        public DateTime From { get; set; }
        [CanBeNull] public string Comment { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public void GenerateNumber(string prefix, long number)
        {
            var documentNumber = new StringBuilder();
            documentNumber.Append(prefix.ToUpper()).Append("-").Append(number.ToString());
            Number = documentNumber.ToString();
        }

    }
}