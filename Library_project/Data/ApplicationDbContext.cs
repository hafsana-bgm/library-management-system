using Library_project.DataModel;
using Library_project.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Library_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
           
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Member> Member { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookLebel> BooksLebels { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceVM> InvoicesVM { get; set; }



    }
}
