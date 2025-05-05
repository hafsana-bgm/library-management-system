using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
        public string? WriterName { get; set; }
        public int BookLebelId { get; set; }
        public int Price {  get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public string? Image { get; set; }
        public bool Isactive {  get; set; }

    }

    public class BookLebel
    {
        [Key]      
        public int BookLebelId { get; set; }
        public string? BookLebelName { get; set; }
    }
}
