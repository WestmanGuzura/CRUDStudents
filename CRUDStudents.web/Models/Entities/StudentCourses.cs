namespace CRUDStudents.web.Models.Entities
{
    public class StudentCourses
    {
        public Guid Id { get; set; }

        // Foreign keys
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public Students Student { get; set; }
        public Courses Course { get; set; }
    }
}
