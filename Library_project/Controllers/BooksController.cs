using Library_project.Data;
using Library_project.DataModel;
using Library_project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using NuGet.Packaging;

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


            ViewBag.Lebellist = _context.BooksLebels.Select(x=>new SelectListItem
            {
                Value = x.BookLebelId.ToString(),
                Text = x.BookLebelName
            }).ToList();

            return View();
        }

  
        [HttpPost]
        public async Task<IActionResult> BookIndex(BookVM books)
        {
            string UniqueFileName = null;

            if(books.UploadImage != null)
            {
                string UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UploadImage");

                UniqueFileName = Guid.NewGuid().ToString() + "_" + books.UploadImage.FileName;
                string filepath = Path.Combine(UploadFolder, UniqueFileName);

                if (!Directory.Exists(UploadFolder))
                {
                    Directory.CreateDirectory(UploadFolder);
                }
                using(var filestream = new FileStream(filepath,FileMode.Create))
                {
                    await books.UploadImage.CopyToAsync(filestream);
                }
            }

            var RealDataModel = new Book();

            RealDataModel.BookName = books.BookName;
            RealDataModel.Price = books.Price;           
            RealDataModel.Image = UniqueFileName;

            _context.Treatise.Add(RealDataModel);

            _context.SaveChanges();

            ViewBag.Lebellist = _context.BooksLebels.Select(x => new SelectListItem
            {
                Value = x.BookLebelId.ToString(),
                Text = x.BookLebelName
            }).ToList();
            return RedirectToAction("BookIndex");
        }
        //{
        //    if(books.BookName !=null && books.WriterName !=null && books.Image !=null && books.Isactive)
        //    {
        //        _context.Add(books);
        //        _context.SaveChanges();
        //    }
        //   
        //}
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
