using System;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Identity;
using BloodDonorTracker.iRepository.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodDonorTracker.Controllers
{
    [ApiController]
    [Route("identity/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IApplicationIdentity _Repository;
        public IdentityController(IApplicationIdentity Repository)
        {
            _Repository = Repository;
        }

        [HttpPost]
        [Route("RegisterUser")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> RegisterUser(RegisterDTO user)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid Information");
            }

            return Ok(await _Repository.RegisterUser(user));
        }

        [HttpGet]
        [Route("Login")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid Information");
            }

            return Ok(await _Repository.Login(email,password));
        }
    }
}