using Account_Infrastructure.Dtos.Account;
using Account_Infrastructure.Repositories.Account;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Acount_Service.Features.Account.Queries
{
    public class AccountQuery : IRequest<AccountViewModel>
    {
        public string Id { get; set; }
    }

    public class AccountQueryHandler : IRequestHandler<AccountQuery, AccountViewModel>
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public AccountQueryHandler(IAccountRepository accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task<AccountViewModel> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepo.SelectAccountById(request.Id);
            return _mapper.Map<AccountViewModel>(account);
        }
    }
}
