using System.Threading.Tasks;
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
        [Route("GetLanding")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetLanding(string userId,long pageNumber,long PageSize)
        {
            return Ok(await _repository.GetLanding(userId,pageNumber,PageSize));
        }
    }
}