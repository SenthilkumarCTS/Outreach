using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MemberOutReachSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        [HttpGet]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        { 
           if(webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException("This Line Should not print in  Development Env.......?????");

            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            
            return Problem(detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        [Route("/error")]
        [HttpGet]
        public IActionResult Error() => Problem();
    }
}
