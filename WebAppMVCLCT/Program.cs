using Microsoft.EntityFrameworkCore;
using WebAppMVCLCT.Models;
using WebAppMVCLCT.Service;

namespace WebAppMVCLCT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            //Middle ware db configuration
            var con = builder.Configuration.GetConnectionString("Constr");
            builder.Services.AddDbContext<Databasecontext>(options =>
            {
                options.UseSqlServer(con);
            });



            builder.Services.AddScoped<IOrdersInterface,IOrderClass>();


            //sesssion

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddHttpContextAccessor();


            // service should be ibjected
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
