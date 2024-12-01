using System.ComponentModel.DataAnnotations;

namespace LearnRecordAPI.Models.DTO
{
    public class learnSubtopicAdminDTO
    {
        public class learnSubtopicAdminAdd
        {
            [Key]
            public Guid topicID { get; set; }
            [Key]
            public Guid subtopicID { get; set; }
            public string subtopicName { get; set; } = string.Empty;
            public int order { get; set; }
            public string description { get; set; } = string.Empty;
            public string creator { get; set; } = string.Empty;
        }

        public class learnSubtopicAdminUpdate
        {
            [Key]
            public Guid topicID { get; set; }
            [Key]
            public Guid subtopicID { get; set; }
            public string subtopicName { get; set; } = string.Empty;
            public int order { get; set; }
            public string description { get; set; } = string.Empty;
            public string updater { get; set; } = string.Empty;
        }
    }
}
