using System.Threading.Tasks;
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
        [HttpGet]
        [Route("GetAuthData")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> GetAuthData()
        {
            var data = "Auth Success";
            return Ok(data);
        }
    }
}