using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public Course Course { get; set; }
        public Trainee Trainee { get; set; }

    }
}
