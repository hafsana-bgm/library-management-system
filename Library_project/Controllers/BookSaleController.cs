using Library_project.Data;
using Library_project.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class BookSaleController : Controller

    {
        private readonly ApplicationDbContext _context;
        public BookSaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Buy_Book()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit_MemberInfo(BuyBook model)
        {

            _context.buyBooks.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Buy_Book");

        }
    }
}
