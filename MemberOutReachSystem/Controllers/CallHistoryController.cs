using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class CallHistoryController : Controller
    {
        public async Task<IActionResult> Index(string mbrid)
        {
            ViewBag.MemberID = mbrid;

            List<CallTrackDetail> CallTrackHistory;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                string requestUri = string.Format("http://localhost:50398/v1/calltrack?MemberId={0}", mbrid);//NOSONAR

                HttpResponseMessage Response = await client.GetAsync(requestUri);

                var callHistory = await Response.Content.ReadAsStringAsync();
                    CallTrackHistory = JsonConvert.DeserializeObject<List<CallTrackDetail>>(callHistory);
              
            }

            return View(CallTrackHistory);
           
        }
    }
}
