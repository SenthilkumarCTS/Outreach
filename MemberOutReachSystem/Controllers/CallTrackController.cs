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
    public class CallTrackController : Controller
    {
        [TempData]
        public string MembId { get; set; }
        public async Task<IActionResult> Index(string mbrid,int DiseaseTypeId)
        {
            ViewBag.MemberId = mbrid;

            TempData["MembId"] = mbrid;
            TempData["DisId"] = DiseaseTypeId;

            List<LookUpData> LookupData = new List<LookUpData>();

            using (var client = new System.Net.Http.HttpClient())
            {   
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                HttpResponseMessage Response = await client.GetAsync("http://localhost:50398/v1/calltrack/CallTrackLookUp"); //NOSONAR

                if (Response.IsSuccessStatusCode)
                {
                    var usrLookup = await Response.Content.ReadAsStringAsync();
                    LookupData = JsonConvert.DeserializeObject<List<LookUpData>>(usrLookup);
                }
            }

            return View(LookupData);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCallTracking()
        {
            MOS_CALL_TRACK_DETAIL_BASE callTrack = new MOS_CALL_TRACK_DETAIL_BASE();

            callTrack.CONTACT_NAME = Request.Form["Cname"];
            callTrack.CALL_STATUS_ID = Convert.ToInt32(Request.Form["ddlStatus"]);
            callTrack.CALL_OUTCOME_ID = Convert.ToInt32(Request.Form["ddlOutcome"]);
            callTrack.Call_Notes = Request.Form["CNotes"];
            callTrack.Call_DateTime = Convert.ToDateTime(Request.Form["CDateTime"]);
            callTrack.RELATIONSHIP_ID = Convert.ToInt32(Request.Form["ddlRelation"]);
            callTrack.MBR_IDENTIFIER = Convert.ToString(TempData["MembId"]);
            callTrack.Call_Duration = 10;
            callTrack.Reminder_Details = null;
            callTrack.Insert_DTS = DateTime.Now;
            callTrack.Upadate_DTS = DateTime.Now;
            callTrack.Insert_User_ID = 4;
            callTrack.Update_User_ID = 4;

            string url = default;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var ctDetails = System.Text.Json.JsonSerializer.Serialize(callTrack);
                var content = new System.Net.Http.StringContent(ctDetails.ToString(), System.Text.Encoding.UTF8, "application/json");
                var postTask = await client.PostAsync("http://localhost:50398/v1/calltrack/SaveCallTrack", content);  //NOSONAR

                if (postTask.IsSuccessStatusCode)
                {
                    url = string.Format("/Assessment/Index?mbrid={0}&DiseaseTypeId={1}", Convert.ToString(TempData["MembId"]), Convert.ToString(TempData["DisId"]));
                }
            }


            return Redirect(url); 
        }
    }
}
