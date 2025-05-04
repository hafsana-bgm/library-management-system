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
            var data = _context.Member.Where(x=>true).ToList() ;
            return View(data);
        }

        public IActionResult MemberEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var Bookdata = _context.Member.FirstOrDefault(x => x.MemberId == id);
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

        [HttpPost]

        public IActionResult MemberDelete(int? id)
        {
            try
            {
               
                    var member = _context.Member.FirstOrDefault(x => x.MemberId == id);
                if (member != null)
                    {
                        _context.Member.Remove(member);
                        _context.SaveChanges();
                        return Json(new{success = true});
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
              
                
          
            
            }
            catch (Exception ex)
            {
                return Json(new {success = false, message = ex.Message });
            }
        }




        //public IActionResult MemberDelete(int? id)
        //{

        //        if (id == null)
        //        {
        //        return NotFound();
        //        }

        //    var Customer = _context.Member.FirstOrDefault(x => x.MemberId == id);

        //    if (Customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Remove(Customer);
        //    _context.SaveChanges();

        //    return RedirectToAction("MemberList");

        //}

    }
}
