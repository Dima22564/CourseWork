using System.Threading.Tasks;
using ERP.Services.DTO.Auth;

namespace ERP.Services.Services.Abstractions
{
    public interface IAuthService
    {
        public Task<string> Register( RegisterDto registerDto);
        public Task<string> LogIn(LogInDto logInDto);
        public void LogOut();
    }
}