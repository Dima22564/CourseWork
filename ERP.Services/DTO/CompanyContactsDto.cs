namespace ERP.Services.DTO
{
    public class CompanyContactsDto
    {
        public string Phone { get; }
        public string Email { get; }

        public CompanyContactsDto(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }
    }
}