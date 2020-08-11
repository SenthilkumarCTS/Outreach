using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class AssessmentHistoryController : Controller
    {
        public async Task<IActionResult> Index(string mbrid)
        {           
            List<AssessmentHistory> mbrAssHistory = null;

                using (var client = new System.Net.Http.HttpClient())
                {
                    
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    string requestUri = string.Format("http://localhost:50398/v1/Assessment?MemberId={0}", mbrid); //NOSONAR

                    HttpResponseMessage response = await client.GetAsync(requestUri);

                    if (response.IsSuccessStatusCode)
                    {
                        var MbrAssessment = await response.Content.ReadAsStringAsync();
                        mbrAssHistory = JsonConvert.DeserializeObject<List<AssessmentHistory>>(MbrAssessment);
                    }
                }

            
            return View(mbrAssHistory);
        }
    }
}
