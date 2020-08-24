using TW.HotelReservation.Domain.Concrete;
using Xunit;

namespace TW.HotelReservation.Test
{
    public class HotelCtor
    {
        private Hotel _hotel;

        [Fact]
        public void CheckCreationHotel()
        {
            // Arranje / Act
            _hotel = new Hotel("Parque Das Flores", 3, 110, 80, 90, 80);

            // Assert
            Assert.NotNull(_hotel);
        }
    }
}
