using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class AssessmentController : Controller
    {
        
        public async Task<IActionResult> Index(string mbrid, int  DiseaseTypeId)
        {

            TempData["MembId"] = mbrid;
            TempData["DisId"] = DiseaseTypeId;

            ViewBag.DiseaseId = DiseaseTypeId;

            List<Assessment> assessment = new List<Assessment>();

            List<QuestionOptionMapping> QuestionOption = new List<QuestionOptionMapping>();

            using (var client = new System.Net.Http.HttpClient())
            {   
                
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                HttpResponseMessage Response = await client.GetAsync("http://localhost:50398/v1/Assessment/GetQuestion");  //NOSONAR

                if (Response.IsSuccessStatusCode)
                {
                    var usrLookup = await Response.Content.ReadAsStringAsync();
                    QuestionOption = JsonConvert.DeserializeObject<List<QuestionOptionMapping>>(usrLookup);
                }

                assessment.Add(ViewAssessment(QuestionOption, DiseaseTypeId));
                
                
            }


            return View(assessment);
        }


        private Assessment ViewAssessment(List<QuestionOptionMapping> QuestionOption, int DiseaseTypeId)
        {
            Assessment assessment = new Assessment();
            assessment.QuestionMapping = QuestionOption;
            assessment.DiseaseTypeId = DiseaseTypeId;

            List<QuestionOptionMapping> DiseaseQuestion = QuestionOption.Where(D => D.DISEASE_CD_ID == DiseaseTypeId).ToList();

            List<int> QuestionId = (from qus in DiseaseQuestion
                                    select qus.QUESTION_CD_ID).Distinct().ToList();

            assessment.QuestionId = QuestionId;

            return assessment;
        }

        [HttpPost]
        public async Task<IActionResult> SaveAssessment()
        {
            string mbrid = MemberID();
            int diseaseId = DiseaseId();

            int assesmentID = await GetMemberAssessment(mbrid);

            List<MOS_ASSESSMENT_DETAILS_BASE> assessmentDetail = new List<MOS_ASSESSMENT_DETAILS_BASE>();

            if (diseaseId == 1) // MA
            {
                ConstructAssessment(mbrid, assesmentID, assessmentDetail, diseaseId);
            }
            else if (diseaseId == 2) //OMW
            {
                ConstructAssessment(mbrid, assesmentID, assessmentDetail, diseaseId);
            }
            else if (diseaseId == 3) //HTN
            {
                ConstructAssessment(mbrid, assesmentID, assessmentDetail, diseaseId);
            }
            else if (diseaseId == 4) //DCC
            {
                // C# Advanced 1 :: No Trailing Method
                ConstructAssessment(mbrid: mbrid, assesmentID: assesmentID, diseaseId: diseaseId, assessmentDetail: assessmentDetail);
            }

            string url = default;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var AssessmentDetails = System.Text.Json.JsonSerializer.Serialize(assessmentDetail);
                var content = new System.Net.Http.StringContent(AssessmentDetails.ToString(), System.Text.Encoding.UTF8, "application/json");
                var postTask = await client.PostAsync("http://localhost:50398/v1/Assessment/SaveAssessment", content); //NOSONAR
                
                if(postTask.IsSuccessStatusCode)
                    url = string.Format("/AssessmentHistory/Index?mbrid={0}", Convert.ToString(TempData["MembId"]));

                
            }
                       

            return Redirect(url);

            // C# Advanced 2 :: Nested Function
            string MemberID()
            {
                return Convert.ToString(TempData["MembId"]);
            }

            int DiseaseId()
            {
                return Convert.ToInt32(TempData["DisId"]);
            }
        }

        public async Task<int> GetMemberAssessment(string mbrid)
        {
            List<AssessmentHistory> mbrAssHistory = null;
            
            //C# Advanced 5 :: Default litrals expression
            int AssessmentID = default;

            using (var client = new System.Net.Http.HttpClient())
            {
                
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                string requestUri = string.Format("http://localhost:50398/v1/Assessment?MemberId={0}", mbrid); //NOSONAR

                HttpResponseMessage Response = await client.GetAsync(requestUri);

                if (Response.IsSuccessStatusCode)
                {
                    var MbrAssessment = await Response.Content.ReadAsStringAsync();
                    mbrAssHistory = JsonConvert.DeserializeObject<List<AssessmentHistory>>(MbrAssessment);
                }

                if (mbrAssHistory != null && mbrAssHistory.Count > 0)
                {
                    AssessmentID = mbrAssHistory.OrderByDescending(a => a.Assessment_ID).FirstOrDefault().Assessment_ID;
                }
            }

            return (AssessmentID == 0) ? 1 : (AssessmentID + 1);
        }



        private void ConstructAssessment(string mbrid, int assesmentID, List<MOS_ASSESSMENT_DETAILS_BASE> assessmentDetail,int diseaseId)
        {
            MOS_ASSESSMENT_DETAILS_BASE assDetail;

            int OptionId1 = Convert.ToInt32(Request.Form["1"]);

            assDetail = new MOS_ASSESSMENT_DETAILS_BASE();
            assDetail.Sgk_Option_Map_ID = OptionId1;

            ConstructAssessmentObject(mbrid, assesmentID, assDetail, string.Empty, diseaseId);

            assessmentDetail.Add(assDetail);

            string[] OptionId2 = Request.Form["2"].ToArray();
            foreach (string result in OptionId2)
            {
                if (result != "false")
                {
                    assDetail = new MOS_ASSESSMENT_DETAILS_BASE();
                    assDetail.Sgk_Option_Map_ID = Convert.ToInt32(result);
                    ConstructAssessmentObject(mbrid, assesmentID, assDetail, string.Empty, diseaseId);
                    assessmentDetail.Add(assDetail);
                }
            }

            int OptionId3 = Convert.ToInt32(Request.Form["3"]);
            assDetail = new MOS_ASSESSMENT_DETAILS_BASE();
            assDetail.Sgk_Option_Map_ID = OptionId3;
            ConstructAssessmentObject(mbrid, assesmentID, assDetail, string.Empty, diseaseId);
            assessmentDetail.Add(assDetail);


            int txt1 = 12;
            string OptionId4 = Request.Form["12"];
            assDetail = new MOS_ASSESSMENT_DETAILS_BASE();
            assDetail.Sgk_Option_Map_ID = txt1;
            ConstructAssessmentObject(mbrid, assesmentID, assDetail, OptionId4, diseaseId);
            assessmentDetail.Add(assDetail);

            int txt2 = 13;
            string OptionId5 = Request.Form["13"];
            assDetail = new MOS_ASSESSMENT_DETAILS_BASE();
            assDetail.Sgk_Option_Map_ID = txt2;
            ConstructAssessmentObject(mbrid, assesmentID, assDetail, OptionId5, diseaseId);
            assessmentDetail.Add(assDetail);
            
        }

        private static void ConstructAssessmentObject(string mbrid, int assesmentID, MOS_ASSESSMENT_DETAILS_BASE assDetail,string Notes, int DiseaseTypeID)
        {
            assDetail.Member_Id = mbrid;
            assDetail.Notes = Notes;
            assDetail.Disease_Type_ID = DiseaseTypeID;
            assDetail.Assessment_ID = assesmentID;

            // C# Advanced 3 :: Pattern Matching
            dynamic todayDate = DateTime.Now;
            assDetail.Insert_DTS = todayDate is DateTime ? todayDate : DateTime.Now;

            //C# Advanced 4 :: Out Parameter

            string date = DateTime.Now.ToString();
            if(DateTime.TryParse(date, out DateTime dt))
            {
                assDetail.Update_DTS = dt;
            }
            
            assDetail.Insert_Usr_Id = 4;
            assDetail.Update_Usr_Id = 4;
        }

        
    }
}

