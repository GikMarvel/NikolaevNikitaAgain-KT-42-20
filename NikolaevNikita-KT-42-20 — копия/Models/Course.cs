namespace NikolaevNikita_KT_42_20.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}

