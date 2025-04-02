using Microsoft.EntityFrameworkCore;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Models
{
    public class Databasecontext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=");
        //}

        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options)
        {

        }

        public DbSet<UsersModel> UsersModel { get; set; }


        //db se/t
        public DbSet<ValidateModel> validateModels { get; set; }

        public DbSet<Student> students { get; set; }   
        public DbSet<WebAppMVCLCT.Models.ProductsModel> ProductsModel { get; set; } = default!;


        public DbSet<OrdersModel> ordersModels { get; set; }

    }
}
