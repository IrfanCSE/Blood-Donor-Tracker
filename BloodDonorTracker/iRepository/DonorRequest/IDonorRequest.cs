using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs;
using BloodDonorTracker.DTOs.DonorRequest;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.DonorRequest
{
    public interface IDonorRequest
    {
        public Task<ResponseMessage> PostDonorRequest(CreateDonorRequest obj);
        public Task<List<GetDonorRequest>> GetDonorRequests(long DonorId);
        public Task<PaginationDTO<GetDonorRequest>> GetDonorSendRequests(long DonorId,long pageNumber, long PageSize);
        public Task<GetDonorRequest> GetDonorRequestById(long DonorRequestId);
        public Task UpdateIsRead(long DonorRequest);
        public Task<long> CountOfNotRead(long DonorRequest);
        public Task CancelDonorRequest(long DonorRequestId);
        public Task<ResponseMessage> AcceptOrDeclain(long DonorRequestId,long DonorId, bool Status);
    }
}