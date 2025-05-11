using System.ComponentModel.DataAnnotations;
using CRUDStudents.web.Models.Entities;

namespace CRUDStudents.web.Models
{
    public class AddStudentViewModel
    {
        [Required(ErrorMessage = "Please Provide your valid Name here")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Too short name given? Please provide a valid name.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Name given")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Provide your Email here.")]
        [EmailAddress(ErrorMessage = "Invalid email address provided.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }
        public bool Subscribed { get; set; }
    }
}
