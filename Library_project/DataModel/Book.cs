namespace Library_project.DataModel
{
    public class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }
        public string? WriterName { get; set; } 
        public int Price {  get; set; }
        public string? Image { get; set; }
        public bool Isactive {  get; set; }

    }
}
