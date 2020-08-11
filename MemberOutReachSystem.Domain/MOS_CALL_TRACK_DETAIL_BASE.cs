using System;
using System.ComponentModel.DataAnnotations;

namespace MemberOutReachSystem.Domain
{
    public class MOS_CALL_TRACK_DETAIL_BASE //NOSONAR
    {

        [Key]
        public int SGK_Call_Track_Id { get; set; }

        public int RELATIONSHIP_ID { get; set; }

        public string Call_Notes { get; set; }

        public int CALL_STATUS_ID { get; set; }

        public int CALL_OUTCOME_ID { get; set; }        

        public DateTime Call_DateTime { get; set; }

        public DateTime? Reminder_Details { get; set; }

        public int Call_Duration { get; set; }

        public int Insert_User_ID { get; set; }

        public int Update_User_ID { get; set; }

        public DateTime Insert_DTS { get; set; }

        public DateTime Upadate_DTS { get; set; }

        public string MBR_IDENTIFIER { get; set; }

        public string CONTACT_NAME { get; set; }

    }
}
