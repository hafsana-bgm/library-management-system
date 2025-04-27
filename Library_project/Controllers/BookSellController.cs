using Library_project.Data;
using Library_project.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class BookSellController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookSellController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult BookSells()
        {
            return View();
        }
        [HttpPost]
       
         public IActionResult BookSells(Member Customer)
         {
            if (Customer.MemberPhone !=null )
            {
               
            }
            return View();
         }
   
    }
}
