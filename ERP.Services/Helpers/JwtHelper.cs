using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ERP.Services.Helpers
{
    public class JwtHelper
    {
        public static string GenerateJwtToken(Person user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
                new Claim("id", user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToLongDateString()),
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddDays(10).ToLongDateString()),
                new Claim(JwtRegisteredClaimNames.Iss, "localhost"),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToLongDateString())
            };
            
            byte[] secretBytes = Encoding.UTF8.GetBytes("SecretKeywqewqeqqqqqqqqqqqweeeeeeeeeeeeeeeeeeeqweqe");
            var key = new SymmetricSecurityKey(secretBytes);
            var singingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                claims: claims,
                signingCredentials: singingCredentials);
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedJwt;
        }

        public static void ValidateJwtToken(string token)
        {
        }
    }
}