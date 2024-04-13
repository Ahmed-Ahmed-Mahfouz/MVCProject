using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext db = new ITIContext();
        public IActionResult ShowResult(int id, int crsid)
        {
            var courseResult = db.crsResult
                .Include(cr => cr.Course)
                .Include(cr => cr.Trainee)
                .FirstOrDefault(cr => cr.CourseId == crsid && cr.TraineeId == id);

            TrainDataWithCrsResultViewModel traineeVM = new TrainDataWithCrsResultViewModel();
            traineeVM.TraineeId = courseResult.TraineeId;
            traineeVM.TraineeName = courseResult.Trainee.Name;
            traineeVM.CourseName = courseResult.Course.Name;
            traineeVM.Degree = courseResult.Degree;
            traineeVM.ImageURL = courseResult.Trainee.ImageURL;
            traineeVM.CourseId = (int)courseResult.CourseId;
            _ =courseResult.Degree >= courseResult.Course.minDegree ? traineeVM.Color = "green" : traineeVM.Color = "red";

            return View("ShowResult", traineeVM);

        }
        public IActionResult ShowCourseResult(int id)
        {
            var courseResults = db.crsResult
                .Where(cr => cr.CourseId == id)
                .Include(cr => cr.Trainee)
                .Select(cr => new CourseResultViewModel
                {
                    TraineeName = cr.Trainee.Name,
                    Degree = cr.Degree,
                    Color = cr.Degree >= cr.Course.minDegree ? "green" : "red"
                })
                .ToList();

            return View("ShowCourseResult", courseResults);
        }
        public IActionResult ShowTraineeResult(int id)
        {
            var traineeResults = db.crsResult
                .Where(cr => cr.TraineeId == id)
                .Include(cr => cr.Course)
                .Select(cr => new CourseResultViewModel
                {
                    CourseName = cr.Course.Name,
                    TraineeName = cr.Trainee.Name,
                    Degree = cr.Degree,
                    Color = cr.Degree >= cr.Course.minDegree ? "green" : "red"
                })
                .ToList();

            return View("ShowTraineeResult", traineeResults);
        }
    }
}
