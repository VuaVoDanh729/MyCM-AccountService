using Account_Infrastructure.Dtos;
using Account_Infrastructure.Dtos.Account;
using AccountInfrastructure.context;
using AccountModel.enums;
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
            bool checkUsername = _context.Accounts.Any(a => a.Username.Equals(account.Username));
            if (!checkUsername)
            {
                account.Status = AccountModel.enums.ActivityStatus.ACTIVE;
                _context.Add(account);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> ChangePassword(string id, string old, string newPass)
        {
            
            var isDone = 0;
            if(old.CompareTo(newPass) == 0)
            {
                return isDone;
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id) && a.Password.Equals(old));
                    if (account is null)
                    {
                        isDone = 0;
                    }
                    else
                     {
                        var accountHistory = new AccountModel.models.AccountHistory
                        {
                            Id = Guid.NewGuid().ToString(),
                            AccountId = account.Id,
                            ModifyDate = DateTime.UtcNow,
                            OldPassword = account.Password
                        };
                        _context.AccountHistories.Add(accountHistory);
                        account.Password = newPass;
                        var result = await _context.SaveChangesAsync();
                        if (result > 0)
                        {
                            _context.AccountHistories.Add(new AccountModel.models.AccountHistory
                            {
                                Id = Guid.NewGuid().ToString(),
                                AccountId = account.Id,
                                ModifyDate = DateTime.UtcNow,
                                OldPassword = old
                            });
                            isDone = await _context.SaveChangesAsync();
                        }

                        if (isDone > 0)
                        {
                            transaction.Commit();
                        }
                    }
                }catch(Exception e)
                {
                    transaction.Rollback();
                }
            }
            return isDone;
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

        public async Task<PaggingList<AccountViewModel>> ListAccount(int pageIdx, int pageSize, ActivityStatus status)
        {
            var totalRecord = await _context.Accounts.CountAsync();
            var selectAll = await  _context.Accounts.AsNoTracking().Where(a => a.Status == status).Skip((pageIdx - 1) * pageSize).Take(pageSize).Select(a => _mapper.Map<AccountViewModel>(a)).ToListAsync();

            var result = selectAll.Select(a => _mapper.Map<AccountViewModel>(a)).ToList();
            return new PaggingList<AccountViewModel>(pageIdx, pageSize, totalRecord, result);
        }

        public async Task<AccountViewModel> SelectAccountById(string id)
        {
            var result = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(id));
            return _mapper.Map<AccountViewModel>(result);
        }

        public async Task<int> UpdateAccount(AccountModel.models.Account account)
        {
            var acc = await _context.Accounts.FirstOrDefaultAsync(a => a.Id.Equals(account.Id));
            if (acc == null)
            {
                return 0;
            }
            else
            {
                acc.Username = account.Username;
                acc.AccountHistories.Add(new AccountModel.models.AccountHistory
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = account.Id,
                    ModifyDate = DateTime.UtcNow
                });
                return await _context.SaveChangesAsync();
            }
        }
    }
}
