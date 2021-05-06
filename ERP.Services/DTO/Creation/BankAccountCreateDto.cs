using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class BankAccountCreateDto : CreationDto
    {
        public string Name { get; set; }
        public string AccountOpened { get; set; }
        public long AccountNumber { get; set; }
        public int CurrencyCode { get; set; }
        public long BankBic { get; set; }
        public long CompanyId { get; set; }
    }
}