using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MemberOutReachSystem.Controllers
{
    public class NasaController : Controller
    {
        public async Task<IActionResult> Index()
        {
           Root myDeserializedClass;
            using (var client = new System.Net.Http.HttpClient())
            {
                string requestUri = string.Format("https://api.nasa.gov/planetary/apod?api_key=sTj8jQIfqF1UG6dDKz9YW3S0hgxPMB9hCJk6xa1V");
                HttpResponseMessage Response = await client.GetAsync(requestUri);

                var NasaResponse = await Response.Content.ReadAsStringAsync();

                 myDeserializedClass = JsonConvert.DeserializeObject<Root>(NasaResponse);

            }

            return View(myDeserializedClass);

            
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    
}
