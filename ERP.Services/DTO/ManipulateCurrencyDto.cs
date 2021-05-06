namespace ERP.Services.DTO
{
    public class ManipulateCurrencyDto
    {
        public int NumericCode { get; set; }
        public string Name { get; set; }
        public string CharacterCode { get; set; }
        public float ExchangeRate { get; set; }

        public ManipulateCurrencyDto(int numericCode, string name, string characterCode, float exchangeRate)
        {
            NumericCode = numericCode;
            Name = name;
            CharacterCode = characterCode;
            ExchangeRate = exchangeRate;
        }

        public ManipulateCurrencyDto()
        {
        }
    }
}