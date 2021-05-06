namespace ERP.Services.DTO.Return
{
    public class CurrencyToReturn
    {
        public int numericCode { get; set; }
        public string name { get; set; }
        public string characterCode { get; set; }
        public float exchangeRate { get; set; }
    }
}