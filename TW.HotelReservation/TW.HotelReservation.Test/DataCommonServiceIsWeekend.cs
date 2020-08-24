using System;
using System.Collections.Generic;
using System.Text;
using TW.HotelReservation.Service;
using Xunit;

namespace TW.HotelReservation.Test
{
    public class DataCommonServiceIsWeekend
    {
        [Theory]
        [InlineData(true, "2020-08-23")]
        [InlineData(false, "2020-08-24")]
        public void ReturnIfIsOrNotIsWeekend(bool isWeekend, string date)
        {
            // Assert
            Assert.Equal(isWeekend, DateCommonService.IsWeekend(DateTime.Parse(date)));
        }
    }
}
