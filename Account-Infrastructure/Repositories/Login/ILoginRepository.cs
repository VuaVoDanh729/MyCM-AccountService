using Account_Infrastructure.Dtos.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Repositories.Login
{
    public interface ILoginRepository
    {
        public LoginToken Login(string username, string password);

        public string RefreshToken(string token);

        public bool Register(AccountModel.models.Account account);

        public bool ChangePassword(string username, string oldPass, string newPass);
    }
}
