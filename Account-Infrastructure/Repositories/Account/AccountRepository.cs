using Account_Infrastructure.Dtos;
using Account_Infrastructure.Dtos.Account;
using AccountInfrastructure.context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(AccountContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<HttpResponseMessage> AddAccount(AccountModel.models.Account account)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ChangePassword(AccountModel.models.Account account)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteAccount(AccountModel.models.Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<PaggingList<AccountViewModel>> ListAccount(int pageIdx, int pageSize)
        {
            var totalRecord = await _context.Accounts.CountAsync();
            var selectAll = await  _context.Accounts.Skip((pageIdx - 1) * pageSize).Take(pageSize).Select(a => _mapper.Map<AccountViewModel>(a)).ToListAsync();
            return new PaggingList<AccountViewModel>(pageIdx, pageSize, totalRecord, selectAll);
        }

        public async Task<AccountViewModel> SelectAccountById(string id)
        {
            var result = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return _mapper.Map<AccountViewModel>(result);
        }

        public Task<HttpResponseMessage> UpdateAccount(AccountModel.models.Account account)
        {
            throw new NotImplementedException();
        }
    }
}
