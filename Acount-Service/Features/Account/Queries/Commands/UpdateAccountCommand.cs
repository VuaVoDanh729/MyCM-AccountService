using Account_Infrastructure.Repositories.Account;
using AccountInfrastructure.context;
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
    public class UpdateAccountCommand: IRequest<int>
    {
        public string Id { get; set; }

        public string Username { get; set; }
    }

    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;

        private readonly IMapper _mapper;

        public UpdateAccountHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.UpdateAccount(new AccountModel.models.Account
            {
                Id = request.Id,
                CreatedDate = DateTime.Now,
                Username = request.Username
            });
        }
    }
}
