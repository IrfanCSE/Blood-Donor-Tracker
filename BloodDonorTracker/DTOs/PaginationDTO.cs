using System.Collections.Generic;

namespace BloodDonorTracker.DTOs
{
    public class PaginationDTO<T>
    {
        public List<T> Data { get; set; }
        public long PageNumber { get; set; }
        public long PageSize { get; set; }
        public long Total { get; set; }
    }
}