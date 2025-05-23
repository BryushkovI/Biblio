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
            // добавить необходимые использовани€
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

            // создать новый экземпл€р Startup
            var startup = new Startup(builder.Configuration);
            // настроить все сервисы
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            // настроить конвейер

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(name: "default", pattern: "{controller=Books}/{action=Index}");
            // запустить
            app.Run();
        }
    }
}
