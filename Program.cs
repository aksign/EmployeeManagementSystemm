using EmployeeManagementSystemm.Data;
using EmployeeManagementSystemm.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagementSystemm

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDistributedMemoryCache();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>
                (item => item.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
            builder.Services.AddSession();
            var app = builder.Build();

           
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();


            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider
                    .GetRequiredService<ApplicationDbContext>();

                if (!db.Users.Any(u => u.username == "anmol"))
                {
                    db.Users.Add(new User
                    {
                        username = "anmol",
                        password = BCrypt.Net.BCrypt.HashPassword("Anmol@123")
                    });

                    db.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
