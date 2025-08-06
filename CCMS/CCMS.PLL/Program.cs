using CCMS.DAL.Database;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Repository.Implementation;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CCMS.PLL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Env.Load();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
            connectionString += connectionString[connectionString.Length - 1] == ';' ? "" : ";"
                + $"Server={Environment.GetEnvironmentVariable("SERVER")}"
                + $"Database={Environment.GetEnvironmentVariable("DATABASE")}"
                + $"User Id={Environment.GetEnvironmentVariable("USER_ID")}"
                + $"Password={Environment.GetEnvironmentVariable("PASSWORD")}";

            builder.Services.AddDbContext<CcmsDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IPersonRepo, PersonRepo>();
            builder.Services.AddScoped<IMedicalDeviceRepo, MedicalDeviceRepo>();

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