using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.ViewModels;
using MVCProject.Repository;

namespace MVCProject.Controllers
{
    public class InstructorController : Controller
    {
        //ITIContext db = new ITIContext();
        IInstructorRepository InstructorRepository;
        IDepartmentRepository DepartmentRepository;
        ICourseRepository CourseRepository;
        public InstructorController(IInstructorRepository insRepo, IDepartmentRepository depRepo, ICourseRepository crsRepo)
        {
            InstructorRepository = insRepo;
            DepartmentRepository = depRepo;
            CourseRepository = crsRepo;
        }

        public IActionResult GetCourseForDepartment(int id)
        {
            List<Course> courses = CourseRepository.GetCoursesByDepartmentId(id);
            return Json(courses);
        }

        public IActionResult Index()
        {
            List<Instructor> InsModel = InstructorRepository.GetAll();
            return View("Index", InsModel);
        }
        public IActionResult Details(int id)
        {
            Instructor InsModel = InstructorRepository.GetInstructorWithDepartmentAndCourse(id);
            return View("Details", InsModel);

        }
        public IActionResult New()
        {
            InstructorWithDeptListAndCourseListViewModel InsVm = new InstructorWithDeptListAndCourseListViewModel();
            InsVm.Departments = DepartmentRepository.GetAll();
            InsVm.Courses = CourseRepository.GetAll();

            return View("New", InsVm);
        }
        [HttpPost]
        public IActionResult SaveNew(InstructorWithDeptListAndCourseListViewModel insvm, IFormFile Image)
        {
            if (insvm != null && insvm.Salary > 0)
            {
                Instructor InsModel = new Instructor()
                {
                    Name = insvm.Name,
                    Salary = insvm.Salary,
                    Address = insvm.Address,
                    DepartmentId = insvm.DepartmentId,
                    CourseId = insvm.CourseId
                };

                if (Image.Length > 0)
                {
                    string FileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                    string path = $"wwwroot/images/{FileName}";
                    FileStream fs = new FileStream(path, FileMode.Create);
                    Image.CopyTo(fs);
                    InsModel.ImageURL = FileName;
                }

                InstructorRepository.Insert(InsModel);
                InstructorRepository.Save();
                return RedirectToAction("Index");
            }

            insvm.Departments = DepartmentRepository.GetAll();
            insvm.Courses = CourseRepository.GetAll();
            return View("New", insvm);
        }
    }
}
