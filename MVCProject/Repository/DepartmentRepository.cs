using MVCProject.Models;

namespace MVCProject.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext db;
        public string Id { get; set; }
        public DepartmentRepository(ITIContext iticontext)
        {
            db = iticontext;
            Id = Guid.NewGuid().ToString();
        }

        public List<Department> GetAll()
        {
            return db.Department.ToList();
        }

        public Department Get(int id)
        {
            return db.Department.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Department dept)
        {
            db.Add(dept);
        }

        public void Update(Department dept)
        {
            db.Update(dept);
        }

        public void Delete(int id)
        {
            Department dept = Get(id);
            db.Remove(dept);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
