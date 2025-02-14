using DataProvider;
using Microsoft.EntityFrameworkCore;
namespace BiblioWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // добавить необходимые использовани€
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BiblioContext.BiblioContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("BiblioContext") ?? throw new InvalidOperationException("Connection string 'NotebookContext' not found.")));


            builder.Services.AddTransient<IBookPrivider, BookProviderApi>();
            builder.Services.AddMvc();
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            // создать новый экземпл€р Startup
            var startup = new Startup(builder.Configuration);
            // настроить все сервисы
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            // настроить конвейер
            startup.Configure(app, builder.Environment);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(name: "default", pattern: "{controller=Books}/{action=Index}");
            // запустить
            app.Run();
        }
    }
}
