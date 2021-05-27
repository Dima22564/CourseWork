using System;

namespace ERP.Services.DTO.Return
{
    public class AgreementToReturnDto
    {
        public string Number { get; set; }
        public DateTime From { get; set; }
        public string Comment { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Status { get; set; }
        public PartnerToReturnDto Company { get; set; }
        public CurrencyToReturn Currency { get; set; }
    }
}