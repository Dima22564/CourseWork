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
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<CounterpartyPartner> CounterpartyPartners { get; set; } = new List<CounterpartyPartner>();
        public virtual ICollection<PartnerContactPeople> PartnerContactPeople { get; set; } = new List<PartnerContactPeople>();
        public virtual ICollection<AgreementWithCustomer> AgreementsWithCustomers { get; set; } = new List<AgreementWithCustomer>();
        public virtual ICollection<BusinessProposal> BusinessProposals { get; set; } = new List<BusinessProposal>();
        [CanBeNull] public virtual Employee ResponsiblePerson { get; set; }
        public int? ResponsiblePersonId { get; set; }

        public Partner()
        {
        }
    }    
}