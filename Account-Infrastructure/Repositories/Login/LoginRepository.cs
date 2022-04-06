using Account_Infrastructure.Common;
using Account_Infrastructure.Dtos.Authentication;
using AccountInfrastructure.context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly int ExpiresMinutes = 30;

        private readonly AccountContext _context;

        private readonly IConfiguration _configuration;

        public LoginRepository(AccountContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool ChangePassword(string username, string oldPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginToken> Login(string username, string password)
        {
            string encrPass = PasswordEncrypt.EncryptPass(password);
            var account = _context.Accounts.FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
            if(account != null)
            {
                // Payload of Token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", account.Id),
                    new Claim("Username", account.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(ExpiresMinutes),
                    signingCredentials: signIn);
                var loginToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new LoginToken(loginToken, true);
            }
            else
            {
                return new LoginToken("", false);
            }
        }

        public string RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool Register(AccountModel.models.Account account)
        {
            throw new NotImplementedException();
        }
    }
}
