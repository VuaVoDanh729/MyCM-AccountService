﻿using Account_Infrastructure.Dtos;
using Account_Infrastructure.Dtos.Account;
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

        public Task<PaggingList<AccountViewModel>> ListAccount(int pageIdx, int pageSize);

        public Task<HttpResponseMessage> AddAccount(AccountModel.models.Account account);

        public Task<HttpResponseMessage> UpdateAccount(AccountModel.models.Account account);

        public Task<HttpResponseMessage> DeleteAccount(AccountModel.models.Account account);

        public Task<HttpResponseMessage> ChangePassword(AccountModel.models.Account account);

    }
}