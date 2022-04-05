using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Dtos.Authentication
{
    public class LoginToken
    {
        public string Token { get; set; }

        public bool IsSuccess { get; set; }

        public LoginToken(string token, bool isSuccess = false)
        {
            this.Token = token;
            this.IsSuccess = IsSuccess;
        }
    }
}
