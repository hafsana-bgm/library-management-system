using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class Actionresult
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string?Address { get; set; }
        public string? Contact { get; set; }
    }
}
