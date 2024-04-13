using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IDepartmentRepository
    {
        public string Id { get; set; }
        public List<Department> GetAll();

        public Department Get(int id);

        public void Insert(Department dept);

        public void Update(Department dept);

        public void Delete(int id);

        public int Save();
    }
}