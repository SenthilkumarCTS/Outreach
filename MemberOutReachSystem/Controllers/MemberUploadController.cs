using ExcelDataReader;
using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Controllers
{
    public class MemberUploadController : Controller
    {
        [HttpGet]
        public IActionResult Index(List<MOS_MEMBER_DETAILS_BASE> MemberDetails = null)
        {
            MemberDetails = (MemberDetails == null) ? new List<MOS_MEMBER_DETAILS_BASE>() : MemberDetails;

            return View(MemberDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file,[FromServices] IWebHostEnvironment hostingEnvironment)
        {
            string fileNm = Path.GetFileName(file.FileName);
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{fileNm}";
            using (System.IO.FileStream filestrm = System.IO.File.Create(fileName))
            {
                file.CopyTo(filestrm);
                filestrm.Flush();

            }

            List<MOS_MEMBER_DETAILS_BASE> Members = this.GetMembers(fileNm);

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var Mdetails = System.Text.Json.JsonSerializer.Serialize(Members);
                var content = new System.Net.Http.StringContent(Mdetails.ToString(), System.Text.Encoding.UTF8, "application/json");
                var postTask = await client.PostAsync("http://localhost:50398/v1/member", content);  //NOSONAR

                if (postTask.IsSuccessStatusCode)
                {
                    return View(Members);
                }
            }

            return View();
        }


        private List<MOS_MEMBER_DETAILS_BASE> GetMembers(string FName)
        {
            List<MOS_MEMBER_DETAILS_BASE> MemberDetails = new List<MOS_MEMBER_DETAILS_BASE>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + Path.DirectorySeparatorChar + FName;
            
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        MemberDetails.Add(new MOS_MEMBER_DETAILS_BASE
                        {
                            MBR_IDENTIFIER = reader.GetValue(0).ToString(),
                            MBR_NAME = reader.GetValue(1).ToString(),
                            MBR_AGE = Convert.ToInt32(reader.GetDouble(2)),
                            MBR_CONTACT_NO = reader.GetValue(3).ToString(),
                            MBR_DISEASE_TYPE_ID = Convert.ToInt32(reader.GetDouble(4)),
                            MBR_CLAIM_DETAILS = reader.GetValue(5).ToString(),
                            MBR_DOB = Convert.ToDateTime(reader.GetValue(10)),
                            MBR_ADDRESS1_TXT = reader.GetValue(11).ToString(),
                            MBR_ADDRESS2_TXT = reader.GetValue(12).ToString(),
                            INSERT_DTS = DateTime.Now,
                            UPDATE_DTS = DateTime.Now,
                            INSERT_USR_ID = 4,
                            UPDATE_USR_ID = 4
                        });                        
                    }
                }
            }

            return MemberDetails;
        }
    }
}
