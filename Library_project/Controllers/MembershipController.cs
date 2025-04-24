using System.Diagnostics.Eventing.Reader;
using Library_project.Data;
using Library_project.DataModel;
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

        [HttpPost]
        public IActionResult Membersubmit (Member BookData)
        {
            if(BookData.MemberName !=null && BookData.MemberAddress !=null && BookData.MemberType !=null)
            {
                _context.Add(BookData);
                _context.SaveChanges();

            }
            return RedirectToAction("MemberIndex");
        }

        public IActionResult MemberList()
        {
            var data = _context.Members.Where(x=>true).ToList() ;
            return View(data);
        }

        public IActionResult MemberEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var Bookdata = _context.Members.FirstOrDefault(x => x.MemberId == id);
            return View(Bookdata);
        }

        [HttpPost]
        public IActionResult MemberEdit(Member Bookdata)
        {
            if(Bookdata.MemberName != null && Bookdata.MemberAddress != null && Bookdata.MemberType != null )
            {
                _context.Update(Bookdata);
                    _context.SaveChanges();
            }
            return RedirectToAction("MemberList");
        }

        public IActionResult MemberDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Customer = _context.Members.FirstOrDefault(x => x.MemberId == id);

            if (Customer == null)
            {
                return NotFound();
            }

            _context.Remove(Customer);
            _context.SaveChanges();

            return RedirectToAction("MemberList");

        }
    }
}
