using System.ComponentModel.DataAnnotations;

namespace LearnRecordAPI.Models
{
    public class learnProgressTracker
    {
        [Key]
        public Guid subtopicID { get; set; }
        [Key]
        public Guid processID { get; set; }
        public string processName { get; set; } = string.Empty;
        public int order { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string processStatus { get; set; } = string.Empty;
        public string creator { get; set; } = string.Empty;
        public DateTime createTime { get; set; }
    }
}
