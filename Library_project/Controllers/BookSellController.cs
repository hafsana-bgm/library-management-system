using Library_project.Data;
using Library_project.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

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
                _context.Member.Add(Customer);
                _context.SaveChanges();
                return Json(new { success = true, msg = "Data Saved!" });
            }
            return Json(new{success = false,msg = "faild!" });
         }
   
    }
}
