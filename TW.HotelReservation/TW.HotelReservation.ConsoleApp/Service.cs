﻿using Microsoft.Extensions.DependencyInjection;
using TW.HotelReservation.Repository;
using TW.HotelReservation.Repository.Interfaces;
using TW.HotelReservation.Service;
using TW.HotelReservation.Service.Interfaces;

namespace TW.HotelReservation.ConsoleApp
{
    public static class Service
    {
        private static ServiceCollection _serviceCollection;

        public static void StartupService()
        {
            _serviceCollection = new ServiceCollection();
            ConfigureService(_serviceCollection);
        }

        public static T GetService<T>()
        {
            return _serviceCollection.BuildServiceProvider().GetService<T>();
        }

        private static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ITariffService, TariffService>();
        }
    }
}