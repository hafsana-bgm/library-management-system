using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerIndex()
        {
            return View();
        }
    }
}
