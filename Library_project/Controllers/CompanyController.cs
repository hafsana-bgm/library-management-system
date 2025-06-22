using Library_project.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var getdata = _context.Company.ToList();

            ViewBag.Name = getdata;


            return View();
        }

        public IActionResult Actionresult()
        {
          

            var data = _context.Actionresults.OrderByDescending(x => x.Id).ToList();

            ViewBag.Name= data;

            return View();
        }
    }
}