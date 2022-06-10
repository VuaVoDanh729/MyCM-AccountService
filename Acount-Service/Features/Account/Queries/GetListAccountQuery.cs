using Account_Infrastructure.Dtos;
using Account_Infrastructure.Dtos.Account;
using Account_Infrastructure.Repositories.Account;
using AccountModel.enums;
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
    public class GetListAccountQuery : PagingRequest,IRequest<PaggingList<AccountViewModel>>
    {
        public ActivityStatus Status { get; set; }
    }

    public class GetListAccountHandler : IRequestHandler<GetListAccountQuery, PaggingList<AccountViewModel>>
    {

        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public GetListAccountHandler(IAccountRepository accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task<PaggingList<AccountViewModel>> Handle(GetListAccountQuery request, CancellationToken cancellationToken)
        {
            var result = await _accountRepo.ListAccount(request.PageIdx, request.PageSize, request.Status);
            return result;
        }
    }
}
