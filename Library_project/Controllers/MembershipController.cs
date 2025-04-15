using Library_project.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class MembershipController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MembershipController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult MemberIndex()
        {
            return View();
        }
    }
}
