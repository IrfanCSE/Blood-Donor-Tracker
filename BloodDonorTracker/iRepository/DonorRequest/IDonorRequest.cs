using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.DonorRequest;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.DonorRequest
{
    public interface IDonorRequest
    {
        public Task<ResponseMessage> PostDonorRequest(CreateDonorRequest obj);
        public Task<List<GetDonorRequest>> GetDonorRequests(long DonorId);
        public Task<GetDonorRequest> GetDonorRequestById(long DonorRequestId);
        public Task UpdateIsRead(long DonorRequest);
        public Task<ResponseMessage> AcceptOrDeclain(long DonorRequestId,long DonorId, bool Status);
    }
}