namespace CRUDStudents.web.Models.Entities
{
    public class Students
    {
        public Guid Id { get; set; }

        /*
         1. public Guid Id { get; set; }
            •	Type: Guid (Globally Unique Identifier)
            •	Purpose: This property is used to uniquely identify each student in your system. 
                A Guid is a 128-bit value that is statistically unique, making it ideal for scenarios 
                where you need a unique identifier across systems or databases.         
         * */

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Subscribed { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property: A student can have many courses
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
