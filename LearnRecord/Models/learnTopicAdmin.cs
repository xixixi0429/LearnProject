using System.ComponentModel.DataAnnotations;

namespace LearnRecordAPI.Models
{
    public class learnTopicAdmin
    {
        [Key]
        public Guid? topicID {  get; set; }
        public string? topicName {  get; set; } = string.Empty;
        public string? function {  get; set; } = string.Empty;
        public int? order {  get; set; }
        public string? description {  get; set; } = string.Empty;
        public string? creator {  get; set; } = string.Empty;
        public DateTime? createTime {  get; set; }
        public string? updater {  get; set; } = string.Empty;
        public DateTime? updateTime {  get; set; }
    }
}
