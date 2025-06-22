using Library_project.Controllers;
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
        public DbSet<Companis> Company { get; set; }
       
        public DbSet<Book_info> Books { get; set; }
        public DbSet<Image_lebel> Image { get; set; }
        public DbSet<BuyBook> buyBooks { get; set; }
        public DbSet<Actionresult> Actionresults { get; set; }



    }
}
