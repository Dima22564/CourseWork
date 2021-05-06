using System;

namespace ERP.Services.DTO
{
    public class CompanyInfoDto
    {
        public int TIN { get; }
        public int CRTR { get; }
        public int RegistrationNumber { get; }
        public DateTime RegistrationDate { get; }

        public CompanyInfoDto(int tin, int crtr, int registrationNumber, DateTime registrationDate)
        {
            TIN = tin;
            CRTR = crtr;
            RegistrationNumber = registrationNumber;
            RegistrationDate = registrationDate;
        }
    }
}