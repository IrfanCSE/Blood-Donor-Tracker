using System.Collections.Generic;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs;
using BloodDonorTracker.DTOs.Blood;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.Blood
{
    public interface IBlood
    {
        public Task<PaginationDTO<GetBloodDonor>> GetLanding(string userId, long pageNumber, long PageSize);
        public Task<PaginationDTO<GetBloodRequest>> GetAvailableBloodReqeustLanding(string userId, long pageNumber, long PageSize);
        public Task<PaginationDTO<GetBloodRequest>> GetBloodRequestLanding(string userId, long pageNumber, long PageSize);
        public Task<List<GetBloodRequest>> GetMyBloodRequest(long donorId);
        public Task<PaginationDTO<GetBloodRequest>> GetBloodResponsedLanding(string userId, long pageNumber, long PageSize);
        public Task<GetBloodRequest> GetBloodRequstById(long BloodRequestId);
        public Task<ResponseMessage> PostBloodRequest(CreateBloodRequest obj);
        public Task<ResponseMessage> ResponseOnBloodRequest(long BloodRequestIdPk,long ResponseDonorId);
        public Task<ResponseMessage> RemoveBloodRequest(long BloodRequestIdPk);
        public Task<ResponseMessage> CancelResponseOnBloodRequest(long BloodRequestIdPk,long ResponseDonorId);
        public Task<ResponseMessage> RemoveResponseOnBloodRequest(long BloodRequestIdPk);
    }
}