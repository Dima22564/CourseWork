using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Enums;
using JetBrains.Annotations;

namespace ERP.Domain.Core.Models
{
    [Table("Employees")]
    public class Employee : Person
    {
        public DateTime DateOfBirth { get; set; }
        
        [Column(TypeName = "nchar(1)")]
        public string Gender { get; set; }
        [CanBeNull]
        public float? Salary { get; set; }
        [CanBeNull]
        public DateTime? HiringDate { get; set; }

        [CanBeNull] public long? CompanyId { get; set; }
        [CanBeNull] public virtual Company Company { get; set; }

        public virtual ICollection<Partner> ResponsibleForPartners { get; set; }

        public Employee TakePosition(Position position)
        {
            Position = position;
            return this;
        }

        public bool DoesWorkInCompany()
        {
            return Company != null;
        }

        public Employee WorkInCompany(Company company)
        {
            Company = company;
            return this;
        }

        public Employee()
        {
        }

    }
}