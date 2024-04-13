using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface ICourseRepository
    {
        public string Id { get; set; }
        public List<Course> GetCoursesByDepartmentId(int id);

        public List<Course> GetCoursesAndDepartment();

        public List<Course> GetAll();

        public Course Get(int id);

        public void Insert(Course crs);

        public void Update(Course crs);

        public void Delete(int id);

        public int Save();
    }
}