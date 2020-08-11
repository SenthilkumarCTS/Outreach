using MemberOutReachSystem.Data;
using MemberOutReachSystem.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberOutReachSystem.Business
{
    public class AssessmentRepository
    {
        private const string SP_CALLTRACK_DETAILS = "EXEC [dbo].[MOS_ASSESSMENT_HISTORY_READ] " + "@MEMBER_ID";

        private const string SP_QUSTN_OPTN_DETAILS = "[dbo].[USP_QUESTION_OPTION_READ]";

        public AssessmentRepository(OutreachDbContext outreachDbContext)
        {
            outreaachContext = outreachDbContext;
        }

        public OutreachDbContext outreaachContext { get; }

        public async Task<List<AssessmentHistory>> GetAssessmentDetails(string MemberId)
        {
            List<AssessmentHistory> AssDetails;

            try
            {
             
                SqlParameter MemberID = new SqlParameter("@MEMBER_ID", MemberId);

                AssDetails = await outreaachContext.assessmentDetails.FromSqlRaw(SP_CALLTRACK_DETAILS, MemberID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }


            return AssDetails;
        }


        public async Task<List<QuestionOptionMapping>> GetQuestionOptionMapping()
        {
            List<QuestionOptionMapping> QustnDetails;

            QustnDetails = await outreaachContext.QuestionOptions.FromSqlRaw(SP_QUSTN_OPTN_DETAILS).ToListAsync();

            return QustnDetails;
        }



        public bool SaveAssessment(List<MOS_ASSESSMENT_DETAILS_BASE> assessmentDetails)
        {
            try
            {
               assessmentDetails.ForEach(assessDetail =>
               {
                   outreaachContext.MOS_ASSESSMENT_DETAILS_BASE.Add(assessDetail);
                   outreaachContext.SaveChanges(true);
               });
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }

            return true;
        }

        public List<MOS_ASSESSMENT_DETAILS_BASE> GetMemberSaveAssessment(string MemberId,int AssessmentID)
        {
            try
            {
               
                IEnumerable<MOS_ASSESSMENT_DETAILS_BASE> ViewAssessmentDetails =  outreaachContext.MOS_ASSESSMENT_DETAILS_BASE.Where(view => view.Member_Id == MemberId && view.Assessment_ID == AssessmentID).ToList();
                
                return  ViewAssessmentDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Exception",ex);
            }

           
        }
    }
}
