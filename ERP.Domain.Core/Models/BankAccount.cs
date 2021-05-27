using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class BankAccount : BaseEntity
    {
        public BankAccount()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccountNumber { get; set; }
        public string Name { get; set; }
        public string AccountOpened { get; set; }
        public int CurrencyCode { get; set; }
        [CanBeNull] public virtual Currency Currency { get; set; }

        public long BankBic { get; set; }
        [CanBeNull] public virtual Bank Bank { get; set; }

        public long CompanyTin { get; set; }
        [CanBeNull] public virtual Counterparty Company { get; set; }

        public BankAccount InBank(Bank bank)
        {
            Bank = bank;
            return this;
        }

        public BankAccount InCurrency(Currency currency)
        {
            Currency = currency;
            return this;
        }
        
        public BankAccount AttachCounterparty(Counterparty counterparty)
        {
            Company = counterparty;
            return this;
        }

    }
}    