using System.ComponentModel.DataAnnotations;

namespace LearnRecordAPI.Models.DTO
{
    public class learnTopicAdminDTO
    {
        public class learnTopicAdminAdd
        {
            [Key]
            public Guid topicID { get; set; }
            public string topicName { get; set; } = string.Empty;
            public string function { get; set; } = string.Empty;
            public int order { get; set; }
            public string description { get; set; } = string.Empty;
            public string creator { get; set; } = string.Empty;
        }

        public class learnTopicAdminUpdate
        {
            [Key]
            public Guid topicID { get; set; }
            public string topicName { get; set; } = string.Empty;
            public string function { get; set; } = string.Empty;
            public int order { get; set; }
            public string description { get; set; } = string.Empty;
            public string updater { get; set; } = string.Empty;
        }
    }
}
