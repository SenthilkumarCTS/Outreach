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
    [Route("api/v{verison:ApiVersion}/Assessment")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {

        private readonly AssessmentRepository AssessRepo;

        public AssessmentController(OutreachDbContext OutReachContxt)
        {
            AssessRepo = new AssessmentRepository(OutReachContxt);
        }

        [HttpGet]
        public async Task<IEnumerable<AssessmentHistory>> Get(string MemberId)
        {
            List<AssessmentHistory> AssessmentDetails = null;

            AssessmentDetails = await AssessRepo.GetAssessmentDetails(MemberId);

            return AssessmentDetails;

        }

        [HttpGet("GetQuestion")]        
        public async Task<IEnumerable<QuestionOptionMapping>> GetQuestions()
        {
            List<QuestionOptionMapping> QustOptn;

            QustOptn = await AssessRepo.GetQuestionOptionMapping();

            return QustOptn;
        }


        [HttpPost("SaveAssessment")]
        public IActionResult SaveAssessment([FromBody] List<MOS_ASSESSMENT_DETAILS_BASE> assessmentDetails)
        {

            if (assessmentDetails != null)
            {   
                AssessRepo.SaveAssessment(assessmentDetails);
            }


            return Ok();

        }


        [HttpGet("GetSavedAssessment")]
        public List<MOS_ASSESSMENT_DETAILS_BASE> GetSavedAssessment(string MemberId,int AssessmentID)
        {
            List<MOS_ASSESSMENT_DETAILS_BASE> AssessmentDetails = null;

            AssessmentDetails =  AssessRepo.GetMemberSaveAssessment(MemberId, AssessmentID);

            return AssessmentDetails;

        }

    }
}
