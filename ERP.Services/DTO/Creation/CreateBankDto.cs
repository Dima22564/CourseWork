using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class CreateBankDto : CreationDto
    {
        public long Bic { get; set; }
        public string Tin { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string CorrAccount { get; set; }
        public string Address { get; set; }

        public int CountryCode { get; set; }

        public CreateBankDto()
        {
        }
    }
}