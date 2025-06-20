using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Library_project.Viewww_model
{
    public class Image_Class
    {
        [Key]
        public int Id { get; set; }
        public string? Book_Name { get; set; }
        public string? Book_Description { get; set; }
        public int Book_Price { get; set; }
        public string? Author { get; set; }
        public bool IsActive { get; set; }
        public int Image_levelID { get; set; }
        public int Fine_Amount { get; set; }

        public IFormFile? UploadImage { get; set; }
    }
}
