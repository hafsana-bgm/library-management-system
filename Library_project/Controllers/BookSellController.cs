using Library_project.Data;
using Library_project.DataModel;
using Library_project.ViewModel;
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
                var search = _context.Member.Where(x =>x.MemberPhone.StartsWith(phone)).Select(x => new
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

        [HttpPost]
        public IActionResult OrderList([FromBody]InvoiceVM product)
        {
            try
            {
                if (product != null)
                {
                    if (product.Invoice.InvoiceID != null && product.Invoice.PrinterName != null && product.Invoice.Date != null && product.Invoice.Subtotal != null && product.Invoiceproduct.Discount !=null && product.Invoiceproduct.Total !=null && product.Invoiceproduct.Price !=null && product.Invoiceproduct.Quantity !=null && product.Member.MemberPhone !=null && product.Member.MemberName !=null)
                    {
                        
                        return Json(new { success = true });
                    }
                    return Json(new { success = false });
                }
               

                return Json(new {success=false});


            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Server error: " + ex.Message });
            }
        }

    }
}

