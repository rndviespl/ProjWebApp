using Microsoft.EntityFrameworkCore;
using ProjWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using ProjWebApp.Models;

namespace ProjWebApp
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 10485760; // 10 MB
            });

            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseMySql("data source=166.1.201.241;uid=BrosShopAdm;pwd=BrosShopAdmin;database=bro2test",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql")));

            builder.Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();
            builder.Services.AddAuthentication()
               .AddGoogle(options =>
               {
                   options.ClientId = builder.Configuration["Google:ClientId"];
                   options.ClientSecret = builder.Configuration["Google:ClientSecret"];
               });

            builder.Services.AddControllersWithViews();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // ��� ��������� ����������� ����������� ����� �� wwwroot
            // ��������� ��� ������������ ������ �� ������� �����
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        @"E:\projectbro\ProjWebApp\Src\images"), // ������� ������ ���� � ����������
            //    RequestPath = "/images"
            //});


            app.UseRouting();
            app.UseAuthentication();
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
                    name: "test",
                    pattern: "{controller=Test}/{action=Index}/{id?}");
          

        //        endpoints.MapControllerRoute(
        //               name: "cart",
        //               pattern: "{controller=Cart}/{action=Index}/{iuserIdd?}");
        });

            app.Run();
        }
    }
}
