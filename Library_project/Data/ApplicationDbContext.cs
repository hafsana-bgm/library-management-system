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
<<<<<<< HEAD
        public Microsoft.EntityFrameworkCore.DbSet<Member> Members { get; set; }
        public DbSet<Companis> Company { get; set; }
       
=======
        public DbSet<Member> Members { get; set; }
        public DbSet<Book_info> Books { get; set; }
        public DbSet<Image_lebel> Image { get; set; }
        public DbSet<BuyBook> buyBooks { get; set; }

        //public static implicit operator ApplicationDbContext(ApplicationDBContext v)
        //{
        //    throw new NotImplementedException();
        //}
>>>>>>> 41913b9581a7c0eb4e37c83183f34103c673ecd6
    }
}
