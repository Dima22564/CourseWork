namespace ERP.Services.DTO
{
    public class CompanyAddressDto
    {
        public string LegalAddress { get; }
        public string PhysicalAddress { get; }

        public CompanyAddressDto(string legalAddress, string physicalAddress)
        {
            LegalAddress = legalAddress;
            PhysicalAddress = physicalAddress;
        }
    }
}