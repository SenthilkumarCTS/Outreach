using System.ComponentModel.DataAnnotations;

namespace MemberOutReachSystem.Domain
{
    public class QuestionOptionMapping
    {
        [Key]
        public int SGK_MAPPING_ID { get; set; }

        public int QUESTION_CD_ID { get; set; }

        public int OPTION_CD_ID { get; set; }

        public int DISEASE_CD_ID { get; set; }

        public int CONTROL_TYPE_ID { get; set; }

        public string QUESTION_NM { get; set; }

        public string OPTION_NM { get; set; }

    }
}
