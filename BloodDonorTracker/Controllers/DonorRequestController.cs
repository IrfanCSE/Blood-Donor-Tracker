using System.Threading.Tasks;
using BloodDonorTracker.DTOs.DonorRequest;
using BloodDonorTracker.iRepository.DonorRequest;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodDonorTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorRequestController : ControllerBase
    {
        private readonly IDonorRequest _repository;

        public DonorRequestController(IDonorRequest repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("GetDonorRequestById")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetDonorById(long DonorRequestId)
        {
            return Ok(await _repository.GetDonorRequestById(DonorRequestId));
        }

        [HttpPost]
        [Route("PostDonorRequest")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> PostDonorRequest(CreateDonorRequest obj)
        {
            return Ok(await _repository.PostDonorRequest(obj));
        }

        [HttpGet]
        [Route("GetDonorRequests")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetDonorRequests(long DonorId)
        {
            return Ok(await _repository.GetDonorRequests(DonorId));
        }

        [HttpPatch]
        [Route("AcceptOrDeclain")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> AcceptOrDeclain(long DonorRequestId, long DonorId, bool Status)
        {
            return Ok(await _repository.AcceptOrDeclain(DonorRequestId, DonorId, Status));
        }

        [HttpPatch]
        [Route("UpdateIsRead")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> UpdateIsRead(long DonorRequestId)
        {
            await _repository.UpdateIsRead(DonorRequestId);
            return Ok();
        }
    }
}