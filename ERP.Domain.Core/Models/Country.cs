using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;

namespace ERP.Domain.Core.Models
{
    public class Country : BaseEntity
    {
        public Country()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        
        public virtual ICollection<Bank> Banks { get; set; }

        private Country(int code, string name, string fullName, string code2, string code3)
        {
            Code = Guard.Against.NegativeOrZero(code, nameof(code));
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            FullName = Guard.Against.NullOrEmpty(fullName, nameof(fullName));
            Code2 = Guard.Against.NullOrEmpty(code2, nameof(code2));
            Code3 = Guard.Against.NullOrEmpty(code3, nameof(code3));
        }

        public static Country Create(int code, 
            string name, 
            string fullName, 
            string code2, 
            string code3
            ) => new Country(code, name, fullName, code2, code3);
    }
}