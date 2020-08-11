using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MemberOutReachSystem.Controllers
{
    public class AssessmentViewController : Controller
    {
        public async Task<IActionResult> Index(string mbrid,int AssessmentID)
        {
            List<MOS_ASSESSMENT_DETAILS_BASE> mbrAssHistory = null;
            int DiseaseTypeId = 0;
            using (var client = new System.Net.Http.HttpClient())
            {
                
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                string requestUri = string.Format("http://localhost:50398/v1/Assessment/GetSavedAssessment?MemberId={0}&AssessmentID={1}", mbrid, AssessmentID);  //NOSONAR

                HttpResponseMessage Response = await client.GetAsync(requestUri);

                if (Response.IsSuccessStatusCode)
                {
                    var MbrAssessment = await Response.Content.ReadAsStringAsync();
                    mbrAssHistory = JsonConvert.DeserializeObject<List<MOS_ASSESSMENT_DETAILS_BASE>>(MbrAssessment);
                }
            }

            if (mbrAssHistory.Any())
            {
                DiseaseTypeId = mbrAssHistory.FirstOrDefault().Disease_Type_ID;
            }

            List<Assessment> assessment = new List<Assessment>();

            List<QuestionOptionMapping> QuestionOption = new List<QuestionOptionMapping>();

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                HttpResponseMessage Response = await client.GetAsync("http://localhost:50398/v1/Assessment/GetQuestion"); //NOSONAR

                if (Response.IsSuccessStatusCode)
                {
                    var usrLookup = await Response.Content.ReadAsStringAsync();
                    QuestionOption = JsonConvert.DeserializeObject<List<QuestionOptionMapping>>(usrLookup);
                }

                assessment.Add(ViewAssessment(QuestionOption, DiseaseTypeId, mbrAssHistory));

            }
            

            return View(assessment);
        }

        private Assessment ViewAssessment(List<QuestionOptionMapping> QuestionOption, int DiseaseTypeId, List<MOS_ASSESSMENT_DETAILS_BASE> mbrAssHistory)
        {
            Assessment assessment = new Assessment();
            assessment.QuestionMapping = QuestionOption;
            assessment.DiseaseTypeId = DiseaseTypeId;

            List<QuestionOptionMapping> DiseaseQuestion = QuestionOption.Where(D => D.DISEASE_CD_ID == DiseaseTypeId).ToList();

            List<int> QuestionId = (from qus in DiseaseQuestion
                                    select qus.QUESTION_CD_ID).Distinct().ToList();

            assessment.QuestionId = QuestionId;
            assessment.SaveAssessment = mbrAssHistory;

            return assessment;
        }
    }
}
