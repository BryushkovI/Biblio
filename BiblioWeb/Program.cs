using DataProvider;
using Microsoft.EntityFrameworkCore;
namespace BiblioWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // �������� ����������� �������������
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BiblioContext.BiblioContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("BiblioContext") ?? throw new InvalidOperationException("Connection string 'NotebookContext' not found.")));


            builder.Services.AddTransient<IBookPrivider, BookProviderApi>();
            builder.Services.AddMvc();
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            // ������� ����� ��������� Startup
            var startup = new Startup(builder.Configuration);
            // ��������� ��� �������
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            // ��������� ��������
            startup.Configure(app, builder.Environment);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(name: "default", pattern: "{controller=Books}/{action=Index}");
            // ���������
            app.Run();
        }
    }
}
