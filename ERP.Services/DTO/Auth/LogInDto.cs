namespace ERP.Services.DTO.Auth
{
    public class LogInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LogInDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}