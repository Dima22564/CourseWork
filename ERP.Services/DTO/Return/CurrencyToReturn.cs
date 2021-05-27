namespace ERP.Services.DTO.Return
{
    public class CurrencyToReturn
    {
        public int NumericCode { get; set; }
        public string Name { get; set; }
        public string CharacterCode { get; set; }
        public float ExchangeRate { get; set; }
    }
}