using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class NewUserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<LookUpData> LookupData = new List<LookUpData>();

            using (var client = new System.Net.Http.HttpClient())
            {
                HttpResponseMessage Response = await client.GetAsync("http://localhost:50398/v1/user/GetUserLookUp"); //NOSONAR
          
                if (Response.IsSuccessStatusCode)
                {
                    var usrLookup = await Response.Content.ReadAsStringAsync();
                    LookupData =  JsonConvert.DeserializeObject<List<LookUpData>>(usrLookup);
                }
            }
        
            return View(LookupData);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser()
        {
            string Name = Request.Form["Name"];
            string Username = Request.Form["UserName"];
            string Password = Request.Form["pwd"];
            string Address1 = Request.Form["Address1"];
            string Address2 = Request.Form["Address2"];
            string email = Request.Form["email"];
            string Phone = Request.Form["Phone"];
            string DOB = Request.Form["DOB"];
            string state = Request.Form["ddlState"].ToString();
            string country = Request.Form["ddlCountry"].ToString();

            MOS_USER_DETAILS_BASE newUser = new MOS_USER_DETAILS_BASE();

            newUser.NAME = Name;
            newUser.USERNAME = Username;
            newUser.PASSWORD = Password;
            newUser.ADDRESS1_TXT = Address1;
            newUser.ADDRESS2_TXT = Address2;
            newUser.EMAIL_ID = email;
            newUser.MOBILE_NO = Phone;
            newUser.DOB = Convert.ToDateTime(DOB);
            newUser.STATE = Convert.ToInt32(state);
            newUser.COUNTRY = country;
            newUser.INSERT_DTS = DateTime.Now;
            newUser.UPDATE_DTS = DateTime.Now;
            newUser.INSERT_USR_ID = 4;
            newUser.UPDATE_USR_ID = 4;


            using (var client = new System.Net.Http.HttpClient())
            {

                var Mdetails = System.Text.Json.JsonSerializer.Serialize(newUser);
                var content = new System.Net.Http.StringContent(Mdetails.ToString(), System.Text.Encoding.UTF8, "application/json");
                var postTask = await client.PostAsync("http://localhost:50398/v1/User/NewUserRegister", content);  //NOSONAR

                if (postTask.IsSuccessStatusCode)
                {
                    return View();
                }
            }


            return View();
        }
    }
}

