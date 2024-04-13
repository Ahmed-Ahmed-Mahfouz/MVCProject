using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 25);
            return Content("Data Saved");
        }
        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int age = HttpContext.Session.GetInt32("Age").Value;
            return Content($"Name: {name}, Age: {age}");
        }
    }
}
