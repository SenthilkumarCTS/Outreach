using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;


        public LoginController( ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidateUser()
        {   

            string Username = Request.Form["LoginUser"];
            string Password = Request.Form["LoginPwd"];

            User user = new User();
            user.UserName = Username;
            user.UserPassword = Password;

            _logger.LogInformation("ValidateUser UserName : {0}", Username);

            bool isAuthenticated = false;            

            using (var client = new System.Net.Http.HttpClient())
            {

                var userDetails = System.Text.Json.JsonSerializer.Serialize(user);
                var content = new System.Net.Http.StringContent(userDetails.ToString(), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage =  await client.PostAsync("http://localhost:50398/v1/user/authenticate", content);//NOSONAR
                string token = responseMessage.Content.ReadAsStringAsync().Result;

                if(responseMessage.IsSuccessStatusCode)
                    isAuthenticated = true;

                HttpContext.Session.SetString("token", token);
            }


            if (isAuthenticated)
            {
                _logger.LogInformation("Validate Succeed for UserName : {0}", Username);

                return RedirectToAction("index", "Home");
            }

            return null;
        }
    }

    public class JWT //NOSONAR
    {
        public string token { get; set; }

    }

}
