using AccountModel.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountModel.models
{
    public class Account
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public ActivityStatus Status { get; set; }

        public IList<AccountHistory> AccountHistories { get; set; }
    }
}
