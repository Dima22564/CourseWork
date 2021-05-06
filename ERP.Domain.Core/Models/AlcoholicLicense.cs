using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Enums;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class AlcoholicLicense : BaseEntity
    {
        public AlcoholicLicense()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Number { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string LicenceKind { get; set; }
        public string IssuedBy { get; set; }
        [CanBeNull] public ApprovedNotApproved? CheckStatus { get; set; }
        [CanBeNull] public string Comment { get; set; }

        public long CounterpartyId { get; set; }
        public Counterparty Counterparty { get; set; }

        public AlcoholicLicense(
            string number, 
            DateTime validFrom, 
            DateTime validTo, 
            string licenceKind, 
            string issuedBy)
        {
            Number = number;
            ValidFrom = validFrom;
            ValidTo = validTo;
            LicenceKind = licenceKind;
            IssuedBy = issuedBy;
        }

        public bool IsValid()
        {
            return ValidTo > DateTime.Now;
        }

        public void SetComment(string comment)
        {
            Comment = comment;
        }
        
    }
}