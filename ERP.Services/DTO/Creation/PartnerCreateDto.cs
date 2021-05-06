using ERP.Services.DTO.Abstract;

namespace ERP.Services.DTO.Creation
{
    public class PartnerCreateDto : CreationDto
    {
        public string FullName { get; set; }
        public string WorkName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LegalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public string Prefix { get; set; }
        public string Relationship { get; set; }
    }
}