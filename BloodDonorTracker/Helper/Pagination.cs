using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorTracker.Helper
{
    public class Pagination<T> : List<T>
    {
        public static IEnumerable<T> Proccess(long pageSize, long PageNumber, IQueryable<T> Data)
        {
            return Data.Skip(((int)PageNumber - 1) * (int)pageSize).Take((int)pageSize).ToList();
        }
    }
}