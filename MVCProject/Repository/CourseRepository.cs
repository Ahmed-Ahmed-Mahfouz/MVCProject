using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIContext db;
        public string Id { get; set; }
        public CourseRepository(ITIContext iticontext)
        {
            db = iticontext;
            Id = Guid.NewGuid().ToString();
        }

        public List<Course> GetCoursesByDepartmentId(int id)
        {
            return db.Course.Where(c => c.DepartmentId == id).ToList();
        }

        public List<Course> GetCoursesAndDepartment()
        {
            return db.Course.Include("Department").ToList();
        }

        public List<Course> GetAll()
        {
            return db.Course.ToList();
        }

        public Course Get(int id)
        {
            return db.Course.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Course crs)
        {
            db.Add(crs);
        }

        public void Update(Course crs)
        {
            db.Update(crs);
        }

        public void Delete(int id)
        {
            Course crs = Get(id);
            db.Remove(crs);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
