using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        [UniqueName]
        public string Name { get; set; }
        [Range(50, 100, ErrorMessage = "Degree must be between 50 to 100")]
        public int Degree { get; set; }
        [Display(Name = "Minimum Degree")]
        [Remote("CheckMinDegree", "Course", ErrorMessage = "Minimum Degree must be less than Degree", AdditionalFields ="Degree")]
        public int minDegree { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<crsResult>? crsResults { get; set; }
    }
}
