using System.Threading.Tasks;
using BloodDonorTracker.DTOs.HealthReport;
using BloodDonorTracker.iRepository.HealthReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodDonorTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HealthReportController : ControllerBase
    {
        private readonly IHealthReport _repository;
        public HealthReportController(IHealthReport repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetHealthReportById")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetHealthReportById(long donorId)
        {
            return Ok(await _repository.GetHealthReportById(donorId));
        }

        [HttpPost]
        [Route("PostHealthReport")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> PostHealthReport(CreateHealthReportDTO report)
        {
            return Ok(await _repository.CreateHealthReport(report));
        }

        [HttpGet]
        [Route("GetBloodGroups")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetBloodGroups()
        {
            return Ok(await _repository.GetBloodGroups());
        }
    }
}