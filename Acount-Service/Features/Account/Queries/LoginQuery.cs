using Account_Infrastructure.Dtos.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acount_Service.Features.Account.Queries
{
    public class LoginDto: IRequest<LoginToken>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public interface 

    public class LoginQuery
    {

    }
}
