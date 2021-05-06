using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP.Domain.Core.Types
{
    [Owned]
    public class CompanyInfo
    {
        [Column("Crtr")]
        public string Crtr { get; set; }
        
        [Column("RegistrationNumber")]
        public string RegistrationNumber { get; set; }
        
        [Column("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        public CompanyInfo(string crtr, string registrationNumber, DateTime registrationDate)
        {
            Crtr = crtr;
            RegistrationNumber = registrationNumber;
            RegistrationDate = registrationDate;
        }

        public CompanyInfo()
        {
        }
    }
}