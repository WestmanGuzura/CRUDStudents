namespace CRUDStudents.web.Models.Entities
{
    public class Lecturers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Proffesion { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;


        // Navigation property: A lecturer can have many subjects
        public ICollection<Subjects> Subjects { get; set; }

    }
}
