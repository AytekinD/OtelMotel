using OtelMotel.BL.Abstract;
using OtelMotel.BL.Concrete;

namespace OtelMotel.MvcUI.Extensions
{
    public static class MyExtensions
    {
        public static IServiceCollection AddOtelMotelManager(this IServiceCollection services)
        {
            services.AddScoped<IKullaniciManager, KullaniciManager>();
            services.AddScoped<IMusteriManager, MusteriManager>();
            services.AddScoped<IOdaManager, OdaManager>();
            services.AddScoped<IOdaFiyatManager, OdaFiyatManager>();
            services.AddScoped<IRezervasyonManager, RezervasyonManager>();
            services.AddScoped<IRezervasyonDetayManager, RezervasyonDetayMenager>();
            services.AddScoped<IRoleManager, RoleManager>();

            return services;
        }
    }
}
