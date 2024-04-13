using MVCProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.ViewModels
{
    public class InstructorWithDeptListAndCourseListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }
    }
}
