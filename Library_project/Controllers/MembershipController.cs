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
        public IActionResult Submit_MemberInfo(Member model)
        {

            _context.Members.Add(model);
            _context.SaveChanges();

            return RedirectToAction("MemberIndex");

        }
        public IActionResult MemberList()
        {

            var data = _context.Members.ToList();

            return View(data);
        }
        public IActionResult MemberEdit(int id)
        {
            //SELECT* FROM Books where id = 1;
            //Database Query

            var getdata = _context.Members.Where(x => x.Id == id).FirstOrDefault();

            return View(getdata);
        }


        public IActionResult MemberEditSubmit(Member model)
        {

            var getdata = _context.Members.Where(x => x.Id == model.Id).FirstOrDefault();

            if (getdata != null)
            {

                getdata.MemberName = model.MemberName;

                getdata.MemberEmail = model.MemberEmail;
                getdata.MemberPhone = model.MemberPhone;
                getdata.MemberAddress = model.MemberAddress;

                _context.Update(getdata);
                _context.SaveChanges();

            }



            return RedirectToAction("MemberList");
        }

    }
}
