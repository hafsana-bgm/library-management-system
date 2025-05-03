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

        [HttpGet]
        public IActionResult Phone(string phone)
        {
            try
            {
                var search = _context.Member.Where(x => x.MemberPhone.StartsWith(phone)).Select(x => new
                    {
                        memberId = x.MemberId,
                        memberName = x.MemberName,
                        memberPhone = x.MemberPhone,
                        memberAddress = x.MemberAddress
                    })
                    .Take(5).ToList();

                return Json(new { success = true, search });
            }
            catch
            {
                return Json(new { success = false });
            }
        }


    }
}
