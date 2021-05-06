using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class CreateCurrencyDto : CreationDto
    {
        public int NumericCode { get; set; }
        public string Name { get; set; }
        public string CharacterCode { get; set; }
        public float ExchangeRate { get; set; }

        public CreateCurrencyDto(int numericCode, string name, string characterCode, float exchangeRate)
        {
            NumericCode = numericCode;
            Name = name;
            CharacterCode = characterCode;
            ExchangeRate = exchangeRate;
        }

        public CreateCurrencyDto()
        {
        }
    }
}