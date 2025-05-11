using CRUDStudents.web.Models.Entities;

namespace CRUDStudents.web.Models.ViewModals
{
    public class StudentsListViewModel
    {
        public List<Students> Students { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchQuery { get; set; }
    }
}
