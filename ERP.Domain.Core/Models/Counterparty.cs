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
    public class Counterparty : Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Tin { get; set; }

        public string Crtr { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public virtual ICollection<AlcoholicLicense> AlcoholicLicenses { get; set; } = new List<AlcoholicLicense>();
        public virtual ICollection<CounterpartyPartner> CounterpartyPartners { get; set; } = new List<CounterpartyPartner>();
        public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();


        public void AddAlcoholicLicense(AlcoholicLicense license)
        {
            AlcoholicLicenses.Add(license);
        }

        public Counterparty()
        {
        }
    }
}