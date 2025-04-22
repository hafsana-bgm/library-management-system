using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class Borrowing_Book : Controller
    {
        public IActionResult BookLoan()
        {
            return View();
        }
    }
}
