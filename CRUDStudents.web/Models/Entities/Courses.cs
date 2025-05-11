using System.Globalization;

namespace CRUDStudents.web.Models.Entities
{
    public class Courses
    {
        public Guid Id { get; set; }

        public string CourseName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string CourseDescription { get; set; }

        public string Duration { get; set; }

        public int subjects { get; set; }

        // Navigation property: A course can have many subjects
        public ICollection<Subjects> Subjects { get; set; }

        // Navigation property: A course can have many students
        public ICollection<StudentCourses> StudentCourses { get; set; }

    }
}
