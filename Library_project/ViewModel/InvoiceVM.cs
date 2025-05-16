using System.ComponentModel.DataAnnotations;
using Library_project.DataModel;

namespace Library_project.ViewModel
{


    public class InvoiceVM
    {
        public Invoice? Invoice { get; set; }
        public InvoiceProduct? Invoiceproduct { get; set; }
        public Member? Member { get; set; }
    }

    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string? PrinterName { get; set; }
        public DateTime Date { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Discount { get; set; }
    }

    public class InvoiceProduct
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }

    public class Member
    {
        public int MemberId { get; set; }
        public string? MemberName { get; set; }
        public string? MemberPhone { get; set; }
        public string? MemberAddress { get; set; }
    }
}
