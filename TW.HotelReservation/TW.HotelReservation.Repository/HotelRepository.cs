using System.Collections.Generic;
using TW.HotelReservation.Domain.Concrete;
using TW.HotelReservation.Repository.Interfaces;

namespace TW.HotelReservation.Repository
{
    public class HotelRepository : IHotelRepository
    {
        public List<Hotel> GetAll()
        {
            return new List<Hotel>
            {
                new Hotel("Parque Das Flores", 3, 110, 80, 90, 80),
                new Hotel("Jardim Botânico", 4, 160, 110, 60, 50),
                new Hotel("Mar Atlântico", 5, 220, 100, 150, 40)
            };
        }
    }
}
