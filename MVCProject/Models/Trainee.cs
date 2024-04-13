using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<crsResult> crsResults { get; set; }
    }
}
