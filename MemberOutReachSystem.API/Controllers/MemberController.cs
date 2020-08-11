using MemberOutReachSystem.Business;
using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberOutReachSystem.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{verison:ApiVersion}/Member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberRepository mbrRepo;

        public MemberController(MemberDbContext mbrCOntext)
        {
            
            mbrRepo = new MemberRepository(mbrCOntext);
        }
        
        [HttpGet]
        public async Task<IEnumerable<MemberDetail>> Get()
        {


            List<MemberDetail> MemberDetails = null;

            MemberDetails = await mbrRepo.GetMemberDetails();

            return MemberDetails;
        }

        [HttpPost]
        public IActionResult UploadMembers([FromBody] List<MOS_MEMBER_DETAILS_BASE> MemberDetails)
        {
            if (MemberDetails.Count > 0)
            {
                mbrRepo.UploadMemberDetails(MemberDetails);
            }

            return Ok();
        }
    }
}


