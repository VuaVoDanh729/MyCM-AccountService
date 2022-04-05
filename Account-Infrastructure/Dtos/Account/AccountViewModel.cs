using AccountModel.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Dtos.Account
{
    public class AccountViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime CreatedDate { get; set; }

        public ActivityStatus Status { get; set; }
    }
}
