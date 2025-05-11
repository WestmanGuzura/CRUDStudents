using CRUDStudents.web.Data;
using CRUDStudents.web.Models;
using CRUDStudents.web.Models.Entities;
using CRUDStudents.web.Models.ViewModals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudents.web.Controllers
{
    public class StudentsController : Controller
    {

        //make contrustor ctor
        public StudentsController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //get and save data asychronaously
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    // Return the view with validation errors
            //    return View(viewModel);
            //}

            try
            {
                //now we need to use the db context class that we created 
                var student = new Models.Entities.Students
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Subscribed = viewModel.Subscribed
                };

                await DbContext.Students.AddAsync(student);
                await DbContext.SaveChangesAsync();

                // Add success message to TempData
                TempData["SuccessMessage"] = "Student added successfully!";

                return RedirectToAction("List", "Students");
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                // For simplicity, we are just adding the error message to TempData
                TempData["ErrorMessage"] = $"An error occurred while adding the student: {ex.Message}";

                // Return the view with the original data
                return View(viewModel);
            }
        }


        [HttpGet]
        public async Task<IActionResult> List(string searchQuery, int page = 1, int pageSize = 10)
        {
            // Base query
            var query = DbContext.Students.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(s => s.Name.Contains(searchQuery) || s.Email.Contains(searchQuery));
            }

            // Get total count for pagination
            var totalStudents = await query.CountAsync();

            // Apply pagination
            var students = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();



            // Pass data to the view using a ViewModel
            var viewModel = new StudentsListViewModel
            {
                Students = students,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalStudents / (double)pageSize),
                SearchQuery = searchQuery
            };

            return View(viewModel);

            //var students = await DbContext.Students.ToListAsync();

            //return View(students);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await DbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( Students viwModel)
        {
            if (!ModelState.IsValid)
            {
                // Return the view with validation errors
                return View(viwModel);
            }


            try
            {

                var student = await DbContext.Students.FindAsync(viwModel.Id);

                if (student is not null)
                {
                    student.Name = viwModel.Name;
                    student.Email = viwModel.Email;
                    student.Phone = viwModel.Phone;
                    student.Subscribed = viwModel.Subscribed;

                    await DbContext.SaveChangesAsync();

                    // Add success message to TempData
                    TempData["SuccessMessage"] = "Student Updated successfully!";
                }

                return View(student);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                // For simplicity, we are just adding the error message to TempData
                TempData["ErrorMessage"] = $"An error occurred while updating the student: {ex.Message}";
                // Return the view with the original data
                return View(viwModel);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {


            var student = await DbContext.Students.FindAsync(id);

            if (student is not null)
            {
               DbContext.Students.Remove(student);
                await DbContext.SaveChangesAsync();
            }


            // Add success message to TempData
            TempData["ErrorMessage"] = "Student Deleted successfully!";

            return RedirectToAction("List", "Students");

            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                // For simplicity, we are just adding the error message to TempData
                TempData["ErrorMessage"] = $"An error occurred while deleting the student: {ex.Message}";
                // Redirect to the list page
                return RedirectToAction("List", "Students");
            }
        }
    }
}
