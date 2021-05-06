using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Types;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    public class Company : Organization
    {
        public Company()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyId { get; set; }
        public string Tin { get; set; }
        public string Abbreviation { get; set; }
        public string InternationalName { get; set; }
        public CompanyInfo CompanyInfo { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<ClientOrder> ClientOrders { get; set; }

        private Company(string tin, string abbreviation, string internationalName, string fullName, string workName) : base(fullName, workName)
        {
            Tin = Guard.Against.NullOrEmpty(tin, nameof(tin));
            Abbreviation = Guard.Against.NullOrEmpty(abbreviation, nameof(abbreviation));
            InternationalName = Guard.Against.NullOrEmpty(internationalName, nameof(internationalName));
        }

        public static Company Create(
            string tin,
            string abbreviation,
            string internationalName,
            string fullName, 
            string workName) => new Company(tin, abbreviation, internationalName, fullName, workName);

        public void AttachInfo(CompanyInfo companyInfo)
        {
            CompanyInfo = companyInfo;
        }
        
        public void AttachInfo(string crtr, string registrationNumber, DateTime registrationDate)
        {
            CompanyInfo = new CompanyInfo(crtr, registrationNumber, registrationDate);
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

    }
}