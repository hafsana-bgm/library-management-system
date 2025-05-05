using Library_project.Data;
using Library_project.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Account()
        {
            //var viewmodel = new List <AcccountViewModel>
            //{
            //  new AcccountViewModel
            //  {

            //  }

            //}
            return View();
        }
    }
}
