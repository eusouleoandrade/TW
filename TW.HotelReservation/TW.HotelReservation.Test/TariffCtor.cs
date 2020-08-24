using TW.HotelReservation.Domain.Concrete;
using Xunit;

namespace TW.HotelReservation.Test
{
    public class TariffCtor
    {
        private Tariff _tariff;
        private Hotel _hotel;

        [Fact]
        public void CheckCreationTariff()
        {
            // Arranje
            _hotel = new Hotel("Parque Das Flores", 3, 110, 80, 90, 80);
            double price = 240;

            // Act
            _tariff = new Tariff(_hotel, price);

            // Assert
            Assert.NotNull(_tariff);
        }
    }
}
