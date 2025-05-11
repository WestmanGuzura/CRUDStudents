namespace CRUDStudents.web.Models.Entities
{
    public class Subjects
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        // Foreign keys
        public Guid CourseId { get; set; }
        public Guid LecturerId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public Courses Course { get; set; }
        public Lecturers Lecturer { get; set; }


    }
}
