using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class Companis
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyContact { get; set; }
    }
}
