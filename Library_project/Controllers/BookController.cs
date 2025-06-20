using Library_project.Data;
using Library_project.DataModel;
using Library_project.Viewww_model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Library_project.Controllers
{
    public class BookController : Controller  
    {
        private readonly ApplicationDbContext _dbconnection;


        public BookController(ApplicationDbContext dbconnection)
        {
            _dbconnection = dbconnection;
        }


        public IActionResult Book_information()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> SubmitBook_information(Image_Class model)
        {
            String UniqueFileName = null;
            if (model.UploadImage != null)
            {
                String UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image");

                UniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadImage.FileName;

                String filepath = Path.Combine(UploadFolder, UniqueFileName);

                if (!Directory.Exists(UploadFolder))
                {
                    Directory.CreateDirectory(UploadFolder);

                }
                using (var fillestream = new FileStream(filepath, FileMode.Create))
                {
                    await model.UploadImage.CopyToAsync(fillestream);
                }
            }

            var RealDataModel = new Book_info();

            RealDataModel.Book_Name = model.Book_Name;
            RealDataModel.Book_Description = model.Book_Description;
            RealDataModel.Book_Price = model.Book_Price;          
            RealDataModel.Image = UniqueFileName;

            _dbconnection.Books.Add(RealDataModel);
            _dbconnection.SaveChanges();


            return RedirectToAction("Book_information");
        }

        //public IActionResult SubmitBook_information(Book_info model)
        //{


        //    _dbconnection.Books.Add(model);
        //    _dbconnection.SaveChanges();

        //    return RedirectToAction("Book_information");
        //}

        public IActionResult BookList()
        {
            var data = _dbconnection.Books.ToList();

            return View(data);
        }


        public IActionResult BookEdit(int id )
        {
            //SELECT* FROM Books where id = 1;


            var getdata = _dbconnection.Books.Where(x => x.Id == id).FirstOrDefault();

            return View(getdata);
        }

        [HttpPost]
        public IActionResult BookEditSubmit(Book_info model)
        {

            var getdata = _dbconnection.Books.Where(x => x.Id == model.Id).FirstOrDefault();

            if (getdata != null)
            {

                getdata.Book_Name = model.Book_Name;

                getdata.Author = model.Author;
                getdata.Book_Description = model.Book_Description;
                getdata.Book_Price = model.Book_Price;
                
                _dbconnection.Update(getdata);
                _dbconnection.SaveChanges();

            }



            return RedirectToAction("BookList");
        }

        public IActionResult bookDelete(int id) 
        { 
            var book = _dbconnection.Books.FirstOrDefault(x => x.Id == id);

            if (book == null) 
                { 
                return NotFound();  
            
            }
            _dbconnection.Remove(book);
            _dbconnection.SaveChanges();
                

            return RedirectToAction("BookList");
        }

       
    }
}
