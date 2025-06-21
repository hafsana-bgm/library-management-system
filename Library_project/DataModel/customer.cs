using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class customer
    {
        [Key]
        public int id { get; set; }
        public string? Phone { get; set; }
        public string?name { get; set; }
        public string? address { get; set; }
        public int invoiceId { get; set; }
        public string? printersName { get; set; }
        public DateTime date { get; set; }
        
    }
}
