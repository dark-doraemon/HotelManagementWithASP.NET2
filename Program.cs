using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<HotelContext>(option =>
            {
                option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });


            builder.Services.AddScoped<IRepository, Repository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new {controller= "Home",action = "Index"});

           
            app.Run();
        }
    }
}