using System;

namespace MemberOutReachSystem.Domain
{
    public class AssessmentHistory
    {
        public string Member_Id { get; set; }

        public int Disease_Type_ID { get; set; }

        public int Assessment_ID { get; set; }

        public string Disease { get; set; }

        public DateTime Insert_DTS { get; set; }
    }
}
