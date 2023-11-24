using System.Text.Json.Serialization;

namespace NikolaevNikita_KT_42_20.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string? ExamName { get; set; }
        public DateTime? DateOfTest { get; set; }
        public string? ExamCondition { get; set; }

        public int? SubjectId { get; set; }
        [JsonIgnore]
        public Subject? Subject { get; set; }

        public int? StudentId { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
