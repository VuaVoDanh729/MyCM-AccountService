using Account_Infrastructure.Repositories.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Acount_Service.Features.Account.Queries.Commands
{
    public class ChangePasswordCommand : IRequest<int>
    {
        public string id { get; set; }

        public string oldPassword { get; set; }

        public string newPassword { get; set; }
    }

    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, int>
    {
        private readonly IAccountRepository _accountRepository;

        public ChangePasswordHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.ChangePassword(request.id, request.oldPassword, request.newPassword);
        }
    }

}
