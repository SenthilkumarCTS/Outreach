using MemberOutReachSystem.Business;
using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MemberOutReachSystem.API.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{verison:ApiVersion}/User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        private readonly ITokenBuilder tokenBuilder;

        private readonly ILogger _logger;

        public UsersController(ITokenBuilder tknBuilder, AppDbContext context, ILogger<UserController> logger)
        {
            userRepository = new UserRepository(context);
            tokenBuilder = tknBuilder;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult ValidateUser([FromBody] User user)
        {
            _logger.LogInformation("Validate User Request on Date:{0} ", DateTime.Now);


            if (user != null)
            {
                string Token = string.Empty;

                if (userRepository.UserAuthentication(user.UserName, user.UserPassword))
                {
                    Token = tokenBuilder.BuildToken(user.UserName);
                }
                else
                {
                    return Unauthorized();
                }
                return Ok(Token);
            }

            return Unauthorized();

        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Get Request V2 User Controller on Date:{0} ", DateTime.Now);

            return "Response From V2";
        }

        [HttpGet("GetV2Details")]
        public string RequestV2()
        {
            _logger.LogInformation("Get Request V2 User Controller on Date:{0} ", DateTime.Now);

            return Get();
        }

    }
}
