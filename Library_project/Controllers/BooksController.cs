using Library_project.Data;
using Library_project.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        { 
            _context = context;
        }








        public IActionResult BookIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookIndex(Book books)
        {
            if(books.BookName !=null && books.WriterName !=null && books.Image !=null && books.Isactive)
            {
                _context.Add(books);
                _context.SaveChanges();
            }
            return RedirectToAction("BookIndex");
        }
        public IActionResult BookList()
        {
            var data = _context.Treatise.ToList();

            return View(data);
        }

        public IActionResult BookEdit(int? id)
        {
            if (id == null)
            
                return NotFound();

                var book = _context.Treatise.FirstOrDefault(t => t.BookId == id);
                
                return View(book);
           
        }

        [HttpPost]
        public IActionResult BookEdit(Book books)
        {
            if (books.BookName != null && books.WriterName != null  && books.Isactive)
            {
                _context.Update(books);
                _context.SaveChanges();
            }
            return RedirectToAction ("BookList");
        }

        public IActionResult BookDelete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var Member = _context.Treatise.FirstOrDefault(t => t.BookId == id);

            if (Member == null)
            {
                return NotFound();
            }

            _context.Remove(Member);
            _context.SaveChanges();

            return RedirectToAction("BookList");

        }
    }


}
