using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class CreateCountryDto : CreationDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        
        public CreateCountryDto()
        {
        }
    }
}