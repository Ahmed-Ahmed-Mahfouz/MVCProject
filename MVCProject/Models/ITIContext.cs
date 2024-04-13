using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext() : base()
        {

        }
        public ITIContext(DbContextOptions<ITIContext>options):base(options)
        { }
        public DbSet<crsResult> crsResult { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Trainee> Trainee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MVC_Pro;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                               new Department { Id = 1, Name = "IT", Manager = "Ahmed" },
                               new Department { Id = 2, Name = "HR", Manager = "Ali" });
            modelBuilder.Entity<Course>().HasData(
                               new Course { Id = 1, Name = "C#", Degree = 100, minDegree = 60, DepartmentId = 1 },
                               new Course { Id = 2, Name = "Java", Degree = 100, minDegree = 60, DepartmentId = 1 },
                               new Course { Id = 3, Name = "HR", Degree = 100, minDegree = 60, DepartmentId = 2 });
            modelBuilder.Entity<Instructor>().HasData(
                               new Instructor { Id = 1, Name = "Mohamed", ImageURL = "4.jpg", Salary = 10000, Address = "Cairo", DepartmentId = 1},
                               new Instructor { Id = 2, Name = "Ahmed", ImageURL = "5.jpg", Salary = 8000, Address = "Giza", DepartmentId = 1},
                               new Instructor { Id = 3, Name = "Ali", ImageURL = "6.jpg", Salary = 7500, Address = "Alex", DepartmentId = 2});
            modelBuilder.Entity<Trainee>().HasData(
                               new Trainee { Id = 1, Name = "Abdallah", ImageURL = "1.jpg", Address = "Cairo", Grade = 2, DepartmentId = 1 },
                               new Trainee { Id = 2, Name = "Shadi", ImageURL = "2.jpg", Address = "Giza", Grade = 2, DepartmentId = 1 },
                                new Trainee { Id = 3, Name = "Eslam", ImageURL = "3.jpg", Address = "Alex", Grade = 3, DepartmentId = 2 });
            modelBuilder.Entity<crsResult>().HasData(
                               new crsResult { Id = 1, Degree = 50, TraineeId = 1},
                               new crsResult { Id = 2, Degree = 80, TraineeId = 2},
                               new crsResult { Id = 3, Degree = 70, TraineeId = 3},
                               new crsResult { Id = 4, Degree = 90, TraineeId = 1},
                               new crsResult { Id = 5, Degree = 40, TraineeId = 2},
                               new crsResult { Id = 6, Degree = 70, TraineeId = 3},
                               new crsResult { Id = 7, Degree = 60, TraineeId = 1},
                               new crsResult { Id = 8, Degree = 80, TraineeId = 2},
                               new crsResult { Id = 9, Degree = 30, TraineeId = 3});

        }

    }
}
