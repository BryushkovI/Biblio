using AuthAppLib.Model;
using DataProvider;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace BiblioWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // �������� ����������� �������������
            var builder = WebApplication.CreateBuilder(args);

            
            
            //builder.Services.AddIdentity<User, IdentityRole>()
            //        .AddEntityFrameworkStores<BiblioContext.BiblioContext>()
            //        .AddDefaultTokenProviders();

            builder.Services.AddTransient<IBookPrivider, BookProviderApi>();
            builder.Services.AddMvc();

            //builder.Services.AddIdentity<User, IdentityRole>();

            //builder.Services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 8;
            //    options.Lockout.MaxFailedAccessAttempts = 3;
            //    options.Lockout.AllowedForNewUsers = true;
            //});


            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            // ������� ����� ��������� Startup
            var startup = new Startup(builder.Configuration);
            // ��������� ��� �������
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            // ��������� ��������

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(name: "default", pattern: "{controller=Books}/{action=Index}");
            // ���������
            app.Run();
        }
    }
}
