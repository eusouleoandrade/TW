using System;
using System.Collections.Generic;
using System.Text;

namespace TW.HotelReservation.Domain.Concrete
{
    public class Tariff
    {
        public Hotel Hotel { get; private set; }

        public double Price { get; private set; }

        public Tariff(Hotel hotel, double price)
        {
            Hotel = hotel;
            Price = price;
        }
    }
}
