using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Dtos
{
    public class PagingRequest
    {
        public int PageIdx { get; set; }

        public int PageSize { get; set; }

    }
}
