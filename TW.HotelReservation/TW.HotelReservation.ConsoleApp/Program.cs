using Microsoft.Extensions.DependencyInjection;
using System;
using TW.HotelReservation.Domain.Concrete;
using TW.HotelReservation.Domain.TypeValue;
using TW.HotelReservation.Service;
using TW.HotelReservation.Service.Interfaces;

namespace TW.HotelReservation.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Service.StartupService();

            do
            {
                StartHotelReservation();

            } while (true);
        }

        private static void StartHotelReservation()
        {
            try
            {
                // Welcome
                Console.WriteLine("Welcome to Hotel Reservation");
                Console.WriteLine();

                // Client type
                string inputClientType;
                do
                {
                    Console.WriteLine("Hello, what is your customer profile? (1 to REGULAR and 2 to FIDELIDADE)");
                    inputClientType = Console.ReadLine();

                } while (!inputClientType.Equals("1") && !inputClientType.Equals("2"));
                ClientType clientType = inputClientType.Equals("1") ? ClientType.Regular : ClientType.Fidelidade;

                // Period: start date
                string inputStartDate;
                DateTime startDate;
                do
                {
                    Console.WriteLine("Enter the start date: (DD/MM/YYYY)");
                    inputStartDate = Console.ReadLine();

                } while (!inputStartDate.IsDateTime(out startDate));


                // Period: end date
                string inputEndDate;
                DateTime endDate;
                do
                {
                    Console.WriteLine("Enter the end date: (DD/MM/YYYY)");
                    inputEndDate = Console.ReadLine();

                } while (!inputEndDate.IsDateTime(out endDate));

                // Verify best hotel
                ITariffService tariffService = Service.GetServiceProvider().GetService<ITariffService>();
                Tariff bestTariff = tariffService.GetBestTariff(clientType, DateCommonService.GetPeriod(startDate, endDate));

                // Output
                Console.WriteLine($"The cheapest hotel is {bestTariff.Hotel.Name}");
                Console.WriteLine($"The price is R$ {bestTariff.Price}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} - InnserException: {ex.InnerException.Message}");
            }
        }
    }
}