using System;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Blood;
using BloodDonorTracker.iRepository.Blood;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodDonorTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodController : ControllerBase
    {
        private readonly IBlood _repository;

        public BloodController(IBlood repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAvailableDonorLanding")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetAvailableDonorLanding(string userId, long pageNumber, long PageSize)
        {
            return Ok(await _repository.GetLanding(userId, pageNumber, PageSize));
        }

        [HttpGet]
        [Route("GetAvailableBloodReqeustLanding")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetAvailableBloodReqeustLanding(string userId, long pageNumber, long PageSize)
        {
            return Ok(await _repository.GetAvailableBloodReqeustLanding(userId, pageNumber, PageSize));
        }

        [HttpGet]
        [Route("GetBloodRequestByUserLanding")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetBloodRequestByUserLanding(string userId, long pageNumber, long PageSize)
        {
            return Ok(await _repository.GetBloodRequestLanding(userId, pageNumber, PageSize));
        }

        [HttpGet]
        [Route("GetBloodResponsedByUserLanding")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetBloodResponsedByUserLanding(string userId, long pageNumber, long PageSize)
        {
            return Ok(await _repository.GetBloodResponsedLanding(userId, pageNumber, PageSize));
        }

        [HttpGet]
        [Route("GetBloodRequstById")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetBloodRequstById(long BloodRequstId)
        {
            return Ok(await _repository.GetBloodRequstById(BloodRequstId));
        }

        [HttpPost]
        [Route("PostBloodRequest")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> PostBloodRequest(CreateBloodRequest obj)
        {
            return Ok(await _repository.PostBloodRequest(obj));
        }

        [HttpPatch]
        [Route("RemoveBloodRequest")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> RemoveBloodRequest(long BloodRequest)
        {
            return Ok(await _repository.RemoveBloodRequest(BloodRequest));
        }

        [HttpPatch]
        [Route("ResponseOnBloodRequest")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> ResponseOnBloodRequest(long BloodRequestIdPk, long ResponseDonorId)
        {
            return Ok(await _repository.ResponseOnBloodRequest(BloodRequestIdPk, ResponseDonorId));
        }

        [HttpPatch]
        [Route("CancelResponseOnBloodRequest")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> CancelResponseOnBloodRequest(long BloodRequestIdPk, long ResponseDonorId)
        {
            return Ok(await _repository.CancelResponseOnBloodRequest(BloodRequestIdPk, ResponseDonorId));
        }

        [HttpPatch]
        [Route("RemoveResponseOnBloodRequest")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> RemoveResponseOnBloodRequest(long BloodRequestIdPk)
        {
            return Ok(await _repository.RemoveResponseOnBloodRequest(BloodRequestIdPk));
        }
    }
}