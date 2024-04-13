using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IInstructorRepository
    {
        public string Id { get; set; }
        public Instructor GetInstructorWithDepartmentAndCourse(int id);

        public List<Instructor> GetAll();

        public Instructor Get(int id);

        public void Insert(Instructor ins);

        public void Update(Instructor ins);

        public void Delete(int id);

        public int Save();
    }
}