using System;
using System.Threading.Tasks;
using ERP.Data.Abstractions;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using ERP.Services.DTO.Auth;
using ERP.Services.Helpers;
using ERP.Services.Services.Abstractions;

namespace ERP.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<Person> _userRepo;

        public AuthService(IGenericRepository<Person> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            var isUserExists = _userRepo.IsExists(x => x.Email == registerDto.Email); // TODO
            
            if (isUserExists)
            {
                throw new ApplicationException();
            }
            var password = new PasswordHelper(registerDto.Password);
            password.HashPassword();
            var user = Person.Create(registerDto.FullName, registerDto.Phone, registerDto.Email, password.PasswordHash);

            var token = JwtHelper.GenerateJwtToken(user);
            
            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();

            return token;
        }

        public async Task<string> LogIn(LogInDto logInDto)
        {
            var user = await _userRepo.GetAsync(logInDto.Email); // TODO

            if (user == null)
                throw new ApplicationException();
            
            var password = new PasswordHelper(user.Password, logInDto.Password);
            var isPasswordValid = password.VerifyPassword();
            
            if (!isPasswordValid) 
                throw new ApplicationException();
            
            var token = JwtHelper.GenerateJwtToken(user);

            return token;
        }

        public void LogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}