using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TW.HotelReservation.Domain.Concrete;
using TW.HotelReservation.Domain.TypeValue;
using TW.HotelReservation.Repository.Interfaces;
using TW.HotelReservation.Service;
using TW.HotelReservation.Service.Interfaces;
using Xunit;

namespace TW.HotelReservation.Test
{
    public class TariffServiceGetBestTariff
    {
        private ITariffService tariffService;
        private IHotelRepository hotelRepository;

        [Fact]
        public void ReturnOneTariff()
        {
            // Arranje
            List<DateTime> period = new List<DateTime>
            {
                new DateTime(2020, 03, 16)
            };

            // Act
            hotelRepository = new MockHotelRepository();
            tariffService = new TariffService(hotelRepository);
            Tariff tariff = tariffService.GetBestTariff(ClientType.Fidelidade, period);

            // Assert
            Assert.NotNull(tariff);
        }

        [Fact]
        public void ReturnParqueDasFlores330()
        {
            // Arranje
            List<DateTime> period = new List<DateTime>
            {
                new DateTime(2020, 03, 16),
                new DateTime(2020, 03, 17),
                new DateTime(2020, 03, 18),
            };

            // Act
            hotelRepository = new MockHotelRepository();
            tariffService = new TariffService(hotelRepository);
            Tariff tariff = tariffService.GetBestTariff(ClientType.Regular, period);

            // Assert
            Tariff expctedTariff = new Tariff(hotelRepository.GetAll()[0], 330);
            Assert.Equal(JsonConvert.SerializeObject(expctedTariff), JsonConvert.SerializeObject(tariff));
        }

        [Fact]
        public void ReturnJardimBotanico280()
        {
            // Arranje
            List<DateTime> period = new List<DateTime>
            {
                new DateTime(2020, 03, 20),
                new DateTime(2020, 03, 21),
                new DateTime(2020, 03, 22),
            };

            // Act
            hotelRepository = new MockHotelRepository();
            tariffService = new TariffService(hotelRepository);
            Tariff tariff = tariffService.GetBestTariff(ClientType.Regular, period);

            // Assert
            Tariff expctedTariff = new Tariff(hotelRepository.GetAll()[1], 280);
            Assert.Equal(JsonConvert.SerializeObject(expctedTariff), JsonConvert.SerializeObject(tariff));
        }

        [Fact]
        public void ReturnMarAtlantico240()
        {
            // Arranje
            List<DateTime> period = new List<DateTime>
            {
                new DateTime(2020, 03, 26),
                new DateTime(2020, 03, 27),
                new DateTime(2020, 03, 28),
            };

            // Act
            hotelRepository = new MockHotelRepository();
            tariffService = new TariffService(hotelRepository);
            Tariff tariff = tariffService.GetBestTariff(ClientType.Fidelidade, period);

            // Assert
            Tariff expctedTariff = new Tariff(hotelRepository.GetAll()[2], 240);
            Assert.Equal(JsonConvert.SerializeObject(expctedTariff), JsonConvert.SerializeObject(tariff));
        }
    }
}