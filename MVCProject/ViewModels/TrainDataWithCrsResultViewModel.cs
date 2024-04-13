using MVCProject.Models;

namespace MVCProject.ViewModels
{
    public class TrainDataWithCrsResultViewModel
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        public string CourseName { get; set; }
        public int Degree { get; set; }
        public string ImageURL { get; set; }
        public string Color { get; set; }
        public int CourseId { get; set; }
    }
}
