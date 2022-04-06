using Account_Infrastructure.Repositories.Account;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Acount_Service.Features.Account.Commands
{
    public class AddAccountCommand : IRequest<int>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class AccAccountHandler : IRequestHandler<AddAccountCommand, int>
    {
        private readonly IMapper _mapper;

        public readonly IAccountRepository _accountRepo;

        public AccAccountHandler(IMapper mapper, IAccountRepository accountRepo)
        {
            _mapper = mapper;
            _accountRepo = accountRepo;
        }

        public Task<int> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            return _accountRepo.
        }
    }
}
