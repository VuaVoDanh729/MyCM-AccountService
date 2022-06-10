using Account_Infrastructure.Dtos;
using Account_Infrastructure.Dtos.Account;
using AccountModel.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Repositories.Account
{
    public interface IAccountRepository
    {
        public Task<AccountViewModel> SelectAccountById(string id);

        public Task<PaggingList<AccountViewModel>> ListAccount(int pageIdx, int pageSize, ActivityStatus status);

        public Task<int> AddAccount(AccountModel.models.Account account);

        public Task<int> UpdateAccount(AccountModel.models.Account account);

        public Task<int> DeleteAccount(string id);

        public Task<int> ChangePassword(string id, string old, string newPass);

    }
}
