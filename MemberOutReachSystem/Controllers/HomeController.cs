using MemberOutReachSystem.Domain;
using MemberOutReachSystem.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController( ILogger<HomeController> logger)
        {
            _logger = logger;        
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Home Page");

            List<MemberDetail> MemberList = new List<MemberDetail>();

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                
                HttpResponseMessage Response = await client.GetAsync("http://localhost:50398/memberservice"); //NOSONAR


                if (Response.IsSuccessStatusCode)
                {
                    var MbrDetils = await Response.Content.ReadAsStringAsync();
                    MemberList = JsonConvert.DeserializeObject<List<MemberDetail>>(MbrDetils);
                }

            }

            return View(MemberList);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var ExceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = ExceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = ExceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = ExceptionHandlerPathFeature.Error.StackTrace;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

   
       
    }
}
