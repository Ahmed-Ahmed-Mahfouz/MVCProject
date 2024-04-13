using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class CourseController : Controller
    {
        //ITIContext db = new ITIContext();
        ICourseRepository CourseRepository;
        IDepartmentRepository DepartmentRepository;
        public CourseController(ICourseRepository crsRepo, IDepartmentRepository depRepo)
        {
            CourseRepository = crsRepo;
            DepartmentRepository = depRepo;
        }

        public IActionResult CheckMinDegree(int minDegree, int Degree)
        {
            if (minDegree < Degree)
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Index(int pageNumber = 1)
        {
            int pageSize = 3; 
            List<Course> CourseListModel = CourseRepository.GetCoursesAndDepartment()
                                                    .Skip((pageNumber - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToList();
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)CourseRepository.GetAll().Count() / pageSize);
            return View("Index", CourseListModel);
        }


        public IActionResult New()
        {
            ViewData["Depts"] = DepartmentRepository.GetAll();
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Course crs)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    CourseRepository.Insert(crs);
                    CourseRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DepartmentId", "Please Select Department");
                }
            }
            ViewData["Depts"] = DepartmentRepository.GetAll();
            return View("New", crs);
        }
        public IActionResult Edit(int id)
        {
            Course course = CourseRepository.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["Depts"] = DepartmentRepository.GetAll();
            return PartialView("Edit", course);
        }

        [HttpPost]
        public IActionResult SaveEdit(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CourseRepository.Update(course);
                    CourseRepository.Save();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("DepartmentId", "Please Select Department");
                }
            }
            ViewData["Depts"] = DepartmentRepository.GetAll();
            return View("Edit", course);
        }

        public IActionResult Delete(int id)
        {
            Course course = CourseRepository.Get(id);
            if (course == null)
            {
                return NotFound();
            }

            CourseRepository.Delete(id);
            CourseRepository.Save();

            return RedirectToAction(nameof(Index));
        }

    }
}
