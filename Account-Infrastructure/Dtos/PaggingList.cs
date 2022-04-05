using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Infrastructure.Dtos
{
    public class PaggingList<T>
    {
        public int PageIdx { get; set; }

        public int PageSize { get; set; }

        public int TotalRecord { get; set; }

        public List<T> Result { get; set; }

        public PaggingList(int idx, int size, int totalRec, List<T> result)
        {
            PageIdx = idx;
            PageSize = size;
            TotalRecord = totalRec;
            Result = result;
        }
    }
}
