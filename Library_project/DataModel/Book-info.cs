using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.DataModel
{
    public class Book_info
    {
        [Key]
        public int Id { get; set; }
        public string? Book_Name{ get; set; }
        public string? Book_Description{ get; set; }
        public int Book_Price{ get; set; }
        public string? Author { get; set; }
        public bool IsActive { get; set; }
        public int Image_levelID { get; set; }
        public int Fine_Amount{ get; set; }

        public string? Image{ get; set; }
    }

    public class Image_lebel
    {
        [Key]
        public int Image_levelID { get; set; }
        public string? Image_leveName { get; set; }

    }
}
