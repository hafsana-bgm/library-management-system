using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Library_project.DataModel
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        
        public string? PrinterName { get; set; }
        public DateTime? Date { get; set; }
        public int Subtotal { get; set; }
        public int TotalDiscount { get; set; }
        public decimal Discount { get; set; }
    }
}
