using System;
using System.Collections.Generic;
using TW.HotelReservation.Domain.Concrete;
using TW.HotelReservation.Domain.TypeValue;
using TW.HotelReservation.Repository.Interfaces;
using TW.HotelReservation.Service.Interfaces;

namespace TW.HotelReservation.Service
{
    public class TariffService : ITariffService
    {
        private readonly IHotelRepository _hotelRepository;
        public TariffService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Tariff GetBestTariff(ClientType clientType, IList<DateTime> period)
        {
            var hotels = _hotelRepository.GetAll();

            if (hotels is null)
                throw new Exception($"No hotel registered. Action: {nameof(GetBestTariff)}");

            IList<Tariff> tariffList = new List<Tariff>();

            foreach (var hotel in hotels)
            {
                var tariff = CalculateTariffByHotel(clientType, period, hotel);
                tariffList.Add(tariff);
            }

            return CaculateLessTariff(tariffList);
        }

        private Tariff CaculateLessTariff(IList<Tariff> tariffList)
        {
            Tariff lessTariff = null;

            foreach (var tariff in tariffList)
            {
                if (lessTariff == null || tariff.Price < lessTariff.Price)
                    lessTariff = tariff;
                else if (tariff.Price.Equals(lessTariff.Price) && tariff.Hotel.Classification > lessTariff.Hotel.Classification)
                    lessTariff = tariff;
            }

            return lessTariff;
        }

        private Tariff CalculateTariffByHotel(ClientType clientType, IList<DateTime> period, Hotel hotel)
        {
            double price = 0;

            foreach (var date in period)
            {
                if (clientType == ClientType.Regular)
                {
                    if (date.IsWeekend())
                        price += hotel.DailyPriceWeekendRegular;
                    else
                        price += hotel.DailyPriceWeekRegular;
                }
                else if (clientType == ClientType.Fidelidade)
                {
                    if (date.IsWeekend())
                        price += hotel.DailyPriceWeekendFidelidade;
                    else
                        price += hotel.DailyPriceWeekFidelidade;
                }
            }

            return new Tariff(hotel, price);
        }
    }
}
