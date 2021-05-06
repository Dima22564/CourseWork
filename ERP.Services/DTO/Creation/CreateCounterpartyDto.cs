using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class CreateCounterpartyDto : CreationDto
    {
        public string WorkName { get; set; }
        public string FullName { get; set; }
        public string Crtr { get; set; }
        public long Tin { get; set; }
    }
}