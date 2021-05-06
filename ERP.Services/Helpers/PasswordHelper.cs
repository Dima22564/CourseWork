using System;
using JetBrains.Annotations;
using BC = BCrypt.Net.BCrypt;

namespace ERP.Services.Helpers
{
    public class PasswordHelper
    {
        private string Password { get; }
        [CanBeNull] public string PasswordHash { get; set; }

        public PasswordHelper(string password, string passwordHash)
        {
            Password = password;
            PasswordHash = passwordHash;
        }

        public PasswordHelper(string password)
        {
            Password = password;
        }

        public void HashPassword()
        {
            PasswordHash = BC.HashPassword(Password,  BC.GenerateSalt());
        }

        public bool VerifyPassword()
        {
            return BC.Verify(Password, PasswordHash);
        }
    }
}