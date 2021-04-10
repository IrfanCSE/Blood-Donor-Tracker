using System.Threading.Tasks;
using BloodDonorTracker.DTOs.HealthReport;
using BloodDonorTracker.Helper;

namespace BloodDonorTracker.iRepository.HealthReport
{
    public interface IHealthReport
    {
        public Task<GetHealthReportDTO> GetHealthReportById(long donorId);
        public Task<ResponseMessage> CreateHealthReport(CreateHealthReportDTO report);
    }
}