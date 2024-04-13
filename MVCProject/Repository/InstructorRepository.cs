using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        ITIContext db;
        public string Id { get; set; }
        public InstructorRepository(ITIContext iticontext)
        {
            db = iticontext;
            Id = Guid.NewGuid().ToString();
        }

        public Instructor GetInstructorWithDepartmentAndCourse(int id)
        {
            return db.Instructor.Include(i => i.Department).Include(i => i.Course).FirstOrDefault(i => i.Id == id);
        }

        public List<Instructor> GetAll()
        {
            return db.Instructor.ToList();
        }

        public Instructor Get(int id)
        {
            return db.Instructor.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Instructor ins)
        {
            db.Add(ins);
        }

        public void Update(Instructor ins)
        {
            db.Update(ins);
        }

        public void Delete(int id)
        {
            Instructor ins = Get(id);
            db.Remove(ins);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
