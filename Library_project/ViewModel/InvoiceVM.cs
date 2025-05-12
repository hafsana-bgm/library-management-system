using System.ComponentModel.DataAnnotations;
using Library_project.DataModel;

namespace Library_project.ViewModel
{
   
    
    public class InvoiceVM
    {
        public Invoice? invoice { get; set; }
        public InvoiceProduct? InvoiceProduct { get; set; } 
        public Member? member { get; set; } 
     

    }
}
