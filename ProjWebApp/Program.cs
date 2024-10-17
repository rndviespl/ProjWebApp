using Microsoft.EntityFrameworkCore;
using ProjWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProjWebApp
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseMySql("data source=166.1.201.241;uid=BrosShopAdm;pwd=BrosShopAdmin;database=bro2test",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "{controller=Product}/{action=Create}/{id?}");

                endpoints.MapControllerRoute(
                    name: "test",
                    pattern: "{controller=Test}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}
