using System;
using System.ComponentModel.DataAnnotations;

namespace MemberOutReachSystem.Domain
{
    [Serializable]
    public class MemberDetail
    {
        [Key]
        public int SGK_MBR_DETAILS_ID { get; set; }

        public string MBR_IDENTIFIER { get; set; }

        public string MBR_NAME { get; set; }

        public int MBR_AGE { get; set; }

        public string MBR_CONTACT_NO { get; set; }

        public int MBR_DISEASE_TYPE_ID { get; set; }

        public string MBR_DISEASE_NAME { get; set; }

        public string MBR_CLAIM_DETAILS { get; set; }

        public int INSERT_USR_ID { get; set; }

        public int UPDATE_USR_ID { get; set; }

        public DateTime INSERT_DTS { get; set; }

        public DateTime UPDATE_DTS { get; set; }

        public DateTime MBR_DOB { get; set; }

        public string MBR_ADDRESS1_TXT { get; set; }

        public string MBR_ADDRESS2_TXT { get; set; }

    }
}
