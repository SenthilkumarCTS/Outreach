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
    [Route("api/v{verison:ApiVersion}/CallTrack")]
    [ApiController]
    public class CallTrackController : ControllerBase
    {
        private readonly CallTrackRepository CTRepo;

        public CallTrackController(OutreachDbContext OutReachContxt)
        {
            CTRepo = new CallTrackRepository(OutReachContxt);
        }

        [HttpGet]
        public async Task<IEnumerable<CallTrackDetail>> Get(string MemberId)
        {
            List<CallTrackDetail> CallTrackDetails = null;

            CallTrackDetails = await CTRepo.GetCallTrackDetails(MemberId);

            return CallTrackDetails;

        }

        [AllowAnonymous]
        [HttpGet("CallTrackLookUp")]
        public async Task<IEnumerable<LookUpData>> GetCallTrackLookup()
        {
            List<LookUpData> CallTrackLookUp = null;

            CallTrackLookUp = await CTRepo.GetCallTrackLookUpData();

            return CallTrackLookUp;

        }


        
        [HttpPost("SaveCallTrack")]
        public IActionResult SaveCallTrack([FromBody] MOS_CALL_TRACK_DETAIL_BASE Calldetails)
        {
          
            if(Calldetails != null)
            {
                CTRepo.SaveCallTrack(Calldetails);
            }
          

            return Ok();

        }


    }
}
