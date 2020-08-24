using System;
using System.Collections.Generic;
using System.Text;
using TW.HotelReservation.Domain.Concrete;
using TW.HotelReservation.Domain.TypeValue;

namespace TW.HotelReservation.Service.Interfaces
{
    public interface ITariffService
    {
        Tariff GetBestTariff(ClientType clientType, IList<DateTime> period);
    }
}
