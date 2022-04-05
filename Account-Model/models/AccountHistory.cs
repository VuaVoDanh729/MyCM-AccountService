using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountModel.models
{
    public class AccountHistory
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public DateTime ModifyDate { get; set; }

        public string OldPassword { get; set; }

        public Account Account { get; set; }
    }
}
