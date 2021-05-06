using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class Bank : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Bic { get; set; }
        public string Tin { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string CorrAccount { get; set; }
        public string Address { get; set; }

        public int CountryCode { get; set; }
        [CanBeNull] public virtual Country Country { get; set; }
        
        public virtual ICollection<BankAccount> BankAccounts { get; set; }

        public Bank InCountry(Country country)
        {
            Country = country;
            return this;
        }
        

        public Bank()
        {
        }
    }
}