using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Intermediary;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class Partner : Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PartnerId { get; set; }
        public string Relationship { get; set; }
        public string Prefix { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;

        public virtual ICollection<CounterpartyPartner> CounterpartyPartners { get; set; }
        public virtual ICollection<PartnerContactPeople> PartnerContactPeople { get; set; }
        public virtual ICollection<AgreementWithCustomer> AgreementsWithCustomers { get; set; }
        [CanBeNull] public virtual Employee ResponsiblePerson { get; set; }
        public int ResponsiblePersonId { get; set; }

        public Partner()
        {
        }
    }    
}