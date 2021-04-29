using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Donor;
using BloodDonorTracker.iRepository.Donor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodDonorTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DonorController : ControllerBase
    {
        private readonly IDonor _repository;
        public DonorController(IDonor repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetDonorById")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetDonorById(string userId)
        {
            return Ok(await _repository.GetDonorById(userId));
        }

        [HttpGet]
        [Route("GetDonorByNumberId")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetDonorByNumberId(long donorId)
        {
            return Ok(await _repository.GetDonorByNumberId(donorId));
        }

        [HttpPost]
        [Route("PostDonorInfo")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> PostDonorInfo(CreateDonorInfoDTO info)
        {
            return Ok(await _repository.CreateDonor(info));
        }

        [HttpPut]
        [Route("UpdateLocation")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> UpdateLocation(string userId, double Longitude, double Latitude)
        {
            return Ok(await _repository.UpdateLocation(userId, Longitude, Latitude));
        }

        [HttpPut]
        [Route("UpdateMapMode")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> UpdateMapMode(long DonorId, bool Status)
        {
            return Ok(await _repository.UpdateMapMode(DonorId, Status));
        }
    }
}