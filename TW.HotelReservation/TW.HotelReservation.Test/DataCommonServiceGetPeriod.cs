using System;
using System.Collections.Generic;
using System.Text;
using TW.HotelReservation.Service;
using Xunit;

namespace TW.HotelReservation.Test
{
    public class DataCommonServiceGetPeriod
    {
        [Fact]
        public void ReturnPeriod()
        {
            // Arranje
            DateTime startDate = new DateTime(2020, 03, 15);
            DateTime endDate = new DateTime(2020, 03, 18);

            // Act
            List<DateTime> dates = DateCommonService.GetPeriod(startDate, endDate);

            // Assert
            Assert.Equal(DateCommonService.GetPeriod(startDate, endDate), dates);
        }
    }
}
