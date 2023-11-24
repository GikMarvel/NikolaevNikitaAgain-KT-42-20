using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace NikolaevNikita_KT_42_20.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Midname { get; set; }

        public int? GroupId { get; set; }
        [JsonIgnore]
        public Group? Group { get; set; }

        [JsonIgnore]
        public List<Exam>? Exams { get; set; }
        [JsonIgnore]
        public List<Grade>? Grades { get; set; }

        public bool IsDeleted { get; set; }

        //public string? FIO
        //{
        //    get
        //    {
        //        return Surname + " " + Name + " " + Midname;
        //    }
        //}
       
    }
}

