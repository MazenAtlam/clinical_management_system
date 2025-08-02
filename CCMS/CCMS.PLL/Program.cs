using CCMS.DAL.Database;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Repository.Implementation;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace CCMS.PLL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Env.Load();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
            connectionString += connectionString[connectionString.Length - 1] == ';' ? "" : ";"
                + $"Password={Environment.GetEnvironmentVariable("SUPER_ADMIN_PASSWORD")}";

            builder.Services.AddDbContext<CcmsDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IPersonRepo, PersonRepo>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}