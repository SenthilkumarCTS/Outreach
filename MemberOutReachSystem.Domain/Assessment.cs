using System.Collections.Generic;

namespace MemberOutReachSystem.Domain
{
    public class Assessment
    {

        public List<int> QuestionId { get; set; }

        public List<QuestionOptionMapping> QuestionMapping { get; set; }

        public int DiseaseTypeId { get; set; }

        public List<MOS_ASSESSMENT_DETAILS_BASE> SaveAssessment { get; set; }
    }
}   
