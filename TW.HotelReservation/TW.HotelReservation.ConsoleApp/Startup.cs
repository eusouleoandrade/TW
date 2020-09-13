using Microsoft.Extensions.DependencyInjection;
using TW.HotelReservation.Repository;
using TW.HotelReservation.Repository.Interfaces;
using TW.HotelReservation.Service;
using TW.HotelReservation.Service.Interfaces;

namespace TW.HotelReservation.ConsoleApp
{
    public static class Startup
    {
        private static ServiceCollection _serviceCollection;

        public static void StartupConfig()
        {
            _serviceCollection = new ServiceCollection();
            ConfigureService(_serviceCollection);
        }

        public static ServiceProvider GetServiceProvider()
        {
            return _serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ITariffService, TariffService>();
        }
    }
}
