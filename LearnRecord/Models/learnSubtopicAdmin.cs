using System.ComponentModel.DataAnnotations;

namespace LearnRecordAPI.Models
{
    public class learnSubtopicAdmin
    {
        [Key]
        public Guid? topicID { get; set; }
        [Key]
        public Guid? subtopicID { get; set; }
        public string? subtopicName { get; set; } = string.Empty;
        public int? order { get; set; }
        public string? description { get; set; } = string.Empty;
        public string? creator { get; set; } = string.Empty;
        public DateTime? createTime { get; set; }
        public string? updater { get; set; } = string.Empty;
        public DateTime? updateTime { get; set; }
    }
}
