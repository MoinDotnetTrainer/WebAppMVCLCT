using Microsoft.EntityFrameworkCore;

namespace WebAppMVCLCT.Models
{
    public class Databasecontext :DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=");
        //}

        public Databasecontext(DbContextOptions<Databasecontext> options):base(options) { 
        
        }    

        public DbSet<UsersModel> UsersModel { get; set; }

       
    }
}
