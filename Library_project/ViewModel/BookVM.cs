using System.ComponentModel.DataAnnotations;

namespace Library_project.ViewModel
{
    public class BookVM
    {
        [Key]
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
        public string? WriterName { get; set; }
        public int BookLebelId { get; set; }
        public int Price { get; set; }
        public IFormFile? UploadImage { get; set; }
        public bool Isactive { get; set; }
    }

}
