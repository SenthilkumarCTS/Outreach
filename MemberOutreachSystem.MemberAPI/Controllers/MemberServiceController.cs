using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MemberOutreachSystem.MemberAPI.Controllers
{
    [Authorize]   
    [Route("api/[controller]")]
    [ApiController]
    public class MemberServiceController : ControllerBase
    {
        public MemberServiceController(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public IHttpClientFactory HttpClientFactory { get; }

        [HttpGet]
        public async Task<IEnumerable<MemberDetail>> Get()
        {

            try
            {
            
            List<MemberDetail> MemberList = new List<MemberDetail>();

             var client = HttpClientFactory.CreateClient("MemberApi");

            string token =  Request.Headers["Authorization"];

            string[] tokenWitoutBearer = token.Split(" ");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenWitoutBearer[1]);

            HttpResponseMessage Response = await client.GetAsync($"v1/member");

            if (Response.IsSuccessStatusCode)
            {
                var MbrDetils = await Response.Content.ReadAsStringAsync();
                MemberList = JsonConvert.DeserializeObject<List<MemberDetail>>(MbrDetils);
            }
                
                return MemberList;

            }
            catch (Exception ex) 
            {
                throw new ArgumentException("Exception",ex);
            }
        }
    }
}
