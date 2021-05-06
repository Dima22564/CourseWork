using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class Currency : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Код валюты обязателен к заполнению")]
        public int NumericCode { get; set; }
        
        [Required(ErrorMessage = "Имя валюты обязателено к заполнению")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Буквенный код валюты обязателен к заполнению"), Column(TypeName = "nchar(3)")]
        public string CharacterCode { get; set; }
        
        [Required(ErrorMessage = "Ставка обмена обязателена к заполнению")]
        public float ExchangeRate { get; set; }

        public virtual ICollection<AgreementWithCustomer> AgreementsWithCustomers { get; set; }

        public Currency()
        {
        }

        [CanBeNull] public virtual ICollection<BankAccount> BankAccounts { get; set; }

        private Currency(int numericCode, string name, string characterCode, float exchangeRate)
        {
            //NumericCode = Guard.Against.NegativeOrZero(numericCode, nameof(numericCode));
            //Name = Guard.Against.NullOrEmpty(name, nameof(name));
            //CharacterCode = Guard.Against.NullOrEmpty(characterCode, nameof(characterCode));
            //ExchangeRate = Guard.Against.NegativeOrZero(exchangeRate, nameof(exchangeRate));
            NumericCode = numericCode;
            Name = name;
            CharacterCode = characterCode;
            ExchangeRate = exchangeRate;
        }

        public static Currency Create(
            int numericCode,
            string name, 
            string characterCode, 
            float exchangeRate) 
            => new Currency(numericCode, name, characterCode, exchangeRate);
    }
}