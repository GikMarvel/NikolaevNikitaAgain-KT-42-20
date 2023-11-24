using System.Text.Json.Serialization;

namespace NikolaevNikita_KT_42_20.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int? GradeNumber { get; set; }
        public DateTime? GradeDate { get; set; }

        public int? SubjectId { get; set; }
        [JsonIgnore]
        public Subject? Subject { get; set; }

        public int? StudentId { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
