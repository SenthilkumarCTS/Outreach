using System;
using System.ComponentModel.DataAnnotations;

namespace MemberOutReachSystem.Domain
{
    public class MOS_ASSESSMENT_DETAILS_BASE //NOSONAR
    {
        [Key]
        public int Sgk_Mbr_Assessment_Id { get; set; }

        public string Member_Id { get; set; }

        public int Disease_Type_ID { get; set; }

        public int Assessment_ID { get; set; }

        public int Sgk_Option_Map_ID { get; set; }

        public string Notes { get; set; }

        public int Insert_Usr_Id { get; set; }

		public int Update_Usr_Id { get; set; }

		public DateTime Insert_DTS { get; set; }

		public DateTime Update_DTS { get; set; }

	}
}
