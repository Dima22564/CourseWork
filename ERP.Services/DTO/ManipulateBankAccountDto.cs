namespace ERP.Services.DTO
{
    public class ManipulateBankAccountDto
    {
        public string Name { get; set; }
        public string AccountOpened { get; set; }
        public int AccountNumber { get; set; }
        public int CurrencyCode { get; set; }
        public int BankBic { get; set; }
        public int CompanyId { get; set; }

        public ManipulateBankAccountDto()
        {
        }
        
    }
}