using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data.Repositories.Interfaces;
using WebApplication8.Data.Repositories;
using WebApplication8.Data;
using WebApplication8.Services.Interfaces;
using WebApplication8.Services;

namespace WebApplication8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MyShopDataContext>
                (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyShopDB")));

            builder.Services.AddScoped<IUserRespository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=UserIndex}/{id?}");

            app.Run();
        }
    }
}