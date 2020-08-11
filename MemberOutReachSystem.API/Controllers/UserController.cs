using MemberOutReachSystem.Business;
using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberOutReachSystem.API.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{verison:ApiVersion}/User")]
    //[Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        private readonly ITokenBuilder tokenBuilder;

        private readonly ILogger _logger;
        public UserController(ITokenBuilder tknBuilder,AppDbContext context,ILogger<UserController> logger)
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

            _logger.LogInformation("Get Request on Date:{0} ", DateTime.Now);

            return "Test";
        }
       
        [AllowAnonymous]
        [HttpGet("GetUserLookUp")]
        public async Task<IEnumerable<LookUpData>> GetData()
        {
            List<LookUpData> UserLookUpData = null;

            UserLookUpData = await userRepository.GetLookUpData();

            return UserLookUpData;

        }

        [AllowAnonymous]
        [HttpPost("NewUserRegister")]
        public IActionResult UserRegister([FromBody] MOS_USER_DETAILS_BASE UserDetails)
        {
            if (UserDetails != null)
            {
                userRepository.UserRegistration(UserDetails);
            }

            return Ok();
        }
    }
}
