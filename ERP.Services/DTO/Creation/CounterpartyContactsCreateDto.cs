namespace ERP.Services.DTO.Creation
{
    public class CounterpartyContactsCreateDto
    {
        public long Tin { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LegalAddress { get; set; }
        public string PhysicalAddress { get; set; }
    }
}