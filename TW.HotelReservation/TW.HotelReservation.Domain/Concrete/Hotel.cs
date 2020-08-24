using System;
using System.Collections.Generic;
using System.Text;

namespace TW.HotelReservation.Domain.Concrete
{
    public class Hotel
    {
        public string Name { get; private set; }

        public int Classification { get; private set; }

        public double DailyPriceWeekRegular { get; private set; }

        public double DailyPriceWeekFidelidade { get; private set; }

        public double DailyPriceWeekendRegular { get; private set; }

        public double DailyPriceWeekendFidelidade { get; private set; }

        public Hotel(string name, int classification, double dailyPriceWeekRegular, double dailyPriceWeekFidelidade, double dailyPriceWeekendRegular, double dailyPriceWeekendFidelidade)
        {
            Name = name;
            Classification = classification;
            DailyPriceWeekRegular = dailyPriceWeekRegular;
            DailyPriceWeekFidelidade = dailyPriceWeekFidelidade;
            DailyPriceWeekendRegular = dailyPriceWeekendRegular;
            DailyPriceWeekendFidelidade = dailyPriceWeekendFidelidade;
        }
    }
}
