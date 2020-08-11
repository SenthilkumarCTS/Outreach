using System;
using System.ComponentModel.DataAnnotations;

namespace MemberOutReachSystem.Domain
{
    public class MOS_USER_DETAILS_BASE //NOSONAR
    {
        [Key]
        public int SGK_USR_DETAIL_ID { get; set; }

        public string NAME { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }

        public string ADDRESS1_TXT { get; set; }

        public string ADDRESS2_TXT { get; set; }

        public int STATE { get; set; }

        public string COUNTRY { get; set; }

        public string EMAIL_ID { get; set; }

        public string MOBILE_NO { get; set; }

        public DateTime DOB { get; set; }

        public int USERTYPE { get; set; }

        public int INSERT_USR_ID { get; set; }

        public int UPDATE_USR_ID { get; set; }

        public DateTime INSERT_DTS { get; set; }

        public DateTime UPDATE_DTS { get; set; }

    }
}
