using System.Collections.Generic;
using TW.HotelReservation.Domain.Concrete;

namespace TW.HotelReservation.Repository.Interfaces
{
    public interface IHotelRepository
    {
        List<Hotel> GetAll();
    }
}
