using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class BuyBook
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Massage { get; set; }
       
    }
}
