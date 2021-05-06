using System;

namespace ERP.Services.DTO
{
    public class ManipulateCompanyDto
    {
        public string Tin { get; set; }
        public string Crtr { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string Abbreviation { get; set; }
        public string FullName { get; set; }
        public string WorkName { get; set;  }
        public string InternationalName { get; set; }

        public ManipulateCompanyDto(string tin, string crtr, DateTime registrationDate, string registrationNumber, string abbreviation, string fullName, string workName, string internationalName)
        {
            Tin = tin;
            Crtr = crtr;
            RegistrationDate = registrationDate;
            RegistrationNumber = registrationNumber;
            Abbreviation = abbreviation;
            FullName = fullName;
            WorkName = workName;
            InternationalName = internationalName;
        }
    }
}