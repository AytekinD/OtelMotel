using Microsoft.AspNetCore.Authentication.Cookies;
using OtelMotel.MvcUI.Extensions;

namespace OtelMotel.MvcUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddOtelMotelManager();
            #region Cookie Base Authentication Ayarlari
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(p =>
                    {
                        p.LoginPath = "/Login/Giris";
                        p.LogoutPath = "/Login/LogOut";
                        p.Cookie.Name = "OtelMotel";
                        p.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    });
            #endregion

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}