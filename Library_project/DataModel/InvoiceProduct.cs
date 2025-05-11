using System.ComponentModel.DataAnnotations;

namespace Library_project.DataModel
{
    public class InvoiceProduct
    {    
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public decimal Discount { get; set; }
        public int Total { get; set; }
    }


}

