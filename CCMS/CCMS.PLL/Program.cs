using CCMS.BLL.Services.Abstraction;
using CCMS.BLL.Services.Implementation;
using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using CCMS.DAL.Repository.Implementation;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
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

            // Connection String Configuration
            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
            connectionString += connectionString[connectionString.Length - 1] == ';' ? "" : ";"
                + $"Server={Environment.GetEnvironmentVariable("SERVER")}"
                + $";Database={Environment.GetEnvironmentVariable("DATABASE")}";

            // Add DbContext
            builder.Services.AddDbContext<CcmsDbContext>(options
                => options
                .UseLazyLoadingProxies() // Use Lazy Loading
                .UseSqlServer(connectionString)
                );
            
            // Identity
            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true) // Make it false to confirm the email first
                .AddEntityFrameworkStores<CcmsDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            }).AddEntityFrameworkStores<CcmsDbContext>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

            // Add Scoped for Repos
            builder.Services.AddScoped<IAddressRepo, AddressRepo>();
            builder.Services.AddScoped<IBiomedicalEngineerRepo, BiomedicalEngineerRepo>();
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IFamilyMemberRepo, FamilyMemberRepo>();
            builder.Services.AddScoped<ILabDoctorRepo, LabDoctorRepo>();


            builder.Services.AddScoped<IMedicalDeviceRepo, MedicalDeviceRepo>();
            builder.Services.AddScoped<IMedicalDevicesRoomsRepo, MedicalDevicesRoomsRepo>();
            builder.Services.AddScoped<IMedicalHistoryRepo, MedicalHistoryRepo>();
            builder.Services.AddScoped<IPatientFamilyRepo, PatientFamilyRepo>();
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<IPhoneNumberRepo, PhoneNumberRepo>();
            builder.Services.AddScoped<IRoomRepo, RoomRepo>();
            builder.Services.AddScoped<IScanRepo, ScanRepo>();
            builder.Services.AddScoped<IWorkingSlotRepo, WorkingSlotRepo>();
            
            // Add Scoped for Services
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();


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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}