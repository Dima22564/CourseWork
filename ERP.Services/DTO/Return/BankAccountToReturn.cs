namespace ERP.Services.DTO.Return
{
    public class BankAccountToReturn
    {
        public long AccountNumber { get; set; }
        public string Name { get; set; }
        public string AccountOpened { get; set; }
        public CounterpartyToReturn Company { get; set; }
        public CurrencyToReturn Currency { get; set; }
        public BankToReturn Bank { get; set; }
    }
}