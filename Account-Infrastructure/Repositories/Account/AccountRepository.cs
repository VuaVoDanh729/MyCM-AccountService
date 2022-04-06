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

        public async Task<int> AddAccount(AccountModel.models.Account account)
        {
            _context.Add(account);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> ChangePassword(string id, string old, string newPass)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id) && a.Password.Equals(old));
            if(account is null)
            {
                return 0;
            }
            else
            {
                account.Password = newPass;
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteAccount(string id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (account is null)
            {
                return 0;
            }
            else
            {
                account.Status = 0;
                return await _context.SaveChangesAsync();
            }
                
        }

        public async Task<PaggingList<AccountViewModel>> ListAccount(int pageIdx, int pageSize)
        {
            var totalRecord = await _context.Accounts.CountAsync();
            var selectAll = await  _context.Accounts.Skip((pageIdx - 1) * pageSize).Take(pageSize).Select(a => _mapper.Map<AccountViewModel>(a)).ToListAsync();

            var result = selectAll.Select(a => _mapper.Map<AccountViewModel>(a)).ToList();
            return new PaggingList<AccountViewModel>(pageIdx, pageSize, totalRecord, result);
        }

        public async Task<AccountViewModel> SelectAccountById(string id)
        {
            var result = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return _mapper.Map<AccountViewModel>(result);
        }

        public Task<int> UpdateAccount(AccountModel.models.Account account)
        {
            throw new NotImplementedException();
        }
    }
}
