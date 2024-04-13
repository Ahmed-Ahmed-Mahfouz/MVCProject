using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class BindingController : Controller
    {
        public IActionResult TestPrimitive(int age, int crsid)
        {
            return View();
        }
    }
}
