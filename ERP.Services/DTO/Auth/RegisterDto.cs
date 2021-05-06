namespace ERP.Services.DTO.Auth
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterDto(string fullName, string phone, string email, string password)
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
            Password = password;
        }
    }
}