using Library_project.DataModel;
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
        public Microsoft.EntityFrameworkCore.DbSet<Member> Members { get; set; }
        public DbSet<Book> Treatise {  get; set; }
        public DbSet<BookLebel> BooksLebels {  get; set; }


    }
}
