using System;
using System.Threading.Tasks;
using BloodDonorTracker.DTOs.Identity;
using BloodDonorTracker.iRepository.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BloodDonorTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            return Ok(await _Repository.Login(email, password));
        }

        [HttpGet]
        [Route("GetCurrentUser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var claim = HttpContext.User;
            return Ok(await _Repository.GetCurrentUser(claim));
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> EmailExist(string email)
        {
            return Ok(await _Repository.GetEmailExist(email));
        }

        [HttpGet]
        [Route("PasswordChange")]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> PasswordChange(string UserId, string OldPassword, string NewPassword)
        {
            return Ok(await _Repository.PasswordChange(UserId, OldPassword, NewPassword));
        }

        [HttpPut]
        [Route("UpdateUser")]
        [Authorize]
        [SwaggerOperation(Description = "Example {  }")]
        public async Task<IActionResult> UpdateUser(UpdateUser user)
        {
            return Ok(await _Repository.UpdateUser(user));
        }
    }
}