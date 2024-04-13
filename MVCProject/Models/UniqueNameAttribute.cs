using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVCProject.Models
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value?.ToString();
            if (string.IsNullOrEmpty(name))
            {
                return ValidationResult.Success;
            }

            ITIContext db = new ITIContext();
            Course courseFromRequest = (Course)validationContext.ObjectInstance;

            var existingCourse = db.Course.FirstOrDefault(c => c.Name == name && c.DepartmentId == courseFromRequest.DepartmentId && c.Id != courseFromRequest.Id);

            if (existingCourse == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Course Name already exists");
        }
    }
}
