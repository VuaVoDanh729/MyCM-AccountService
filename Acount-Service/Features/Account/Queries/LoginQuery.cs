using Account_Infrastructure.Dtos.Authentication;
using Account_Infrastructure.Repositories.Login;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Acount_Service.Features.Account.Queries
{
    public class LoginDto: IRequest<LoginToken>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginDto, LoginToken>
    {
        private readonly ILoginRepository _loginRepository;

        public LoginQueryHandler(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<LoginToken> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            return await _loginRepository.Login(request.Username, request.Password);
        }
    }
}
