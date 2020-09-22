using System.Threading;
using AutoCreateApiTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCreateApiTest.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    public class CreateApplicationController : ControllerBase
    {

        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly IAutoCreateApplicationService autoCreateApplication;


        public CreateApplicationController(IAutoCreateApplicationService autoCreateApplication, IJwtAuthenticationManager jwtAuthenticationManager)
        {

            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this.autoCreateApplication = autoCreateApplication;

        }

        [Route("CreateApplication")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateApplication(CreateApplicationModel userData, CancellationToken cancellationToken)
        {

            var result = autoCreateApplication.CreateApplication(userData, cancellationToken);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = jwtAuthenticationManager.Authenticate(userCred.username, userCred.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);

        }
    }
}
