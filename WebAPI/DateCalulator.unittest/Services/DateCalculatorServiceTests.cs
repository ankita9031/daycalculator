using DateCalculator.Models;
using DateCalculator.Services;

namespace DateCalulator.unittest.Services
{
    public class DateCalculatorServiceTests
    {
        public DateCalculatorService GetDateCalculatorService()
        {
            return new DateCalculatorService();
        }

        [Fact]
        public void GetPublicHolidayDates_NotSpecialHoliday_NotGuranteedHoliday()
        {
            var _dateCalculatorService = GetDateCalculatorService();
            var publicHolidays = new List<PublicHoliday>();

            publicHolidays.Add(new PublicHoliday("Anzac Day", new DateTime(2022, 04, 25), false, false));

            var publicHolidayDates = _dateCalculatorService.GetPublicHolidayDates(publicHolidays);

            Assert.NotNull(publicHolidayDates);
            Assert.Equal(1, publicHolidayDates.Count);

            Assert.Equal(new DateTime(2022,04,25), publicHolidayDates[0].Date);
        }

        [Fact]
        public void GetPublicHolidayDates_NotSpecialHoliday_GuranteedHoliday()
        {
            var _dateCalculatorService = GetDateCalculatorService();
            var publicHolidays = new List<PublicHoliday>();

            publicHolidays.Add(new PublicHoliday("New Year", new DateTime(2022, 01, 01), true, false));

            var publicHolidayDates = _dateCalculatorService.GetPublicHolidayDates(publicHolidays);

            Assert.NotNull(publicHolidayDates);
            Assert.Equal(1, publicHolidayDates.Count);

            Assert.Equal(new DateTime(2022, 01, 03), publicHolidayDates[0].Date);
        }

        [Fact]
        public void GetPublicHolidayDates_IsSpecialHoliday()
        {
            var _dateCalculatorService = GetDateCalculatorService();
            var publicHolidays = new List<PublicHoliday>();

            publicHolidays.Add(new PublicHoliday("Queens Day", new DateTime(2022, 06, 01), false, true, new SpecialPublicHoliday(DayOfWeek.Monday, 2)));


            var publicHolidayDates = _dateCalculatorService.GetPublicHolidayDates(publicHolidays);

            Assert.NotNull(publicHolidayDates);
            Assert.Equal(1, publicHolidayDates.Count);

            Assert.Equal(new DateTime(2022, 06, 13), publicHolidayDates[0].Date);
        }

        [Fact]
        public void GetPublicHolidayDates_IsSpecialHoliday_NoSpecialHolidaySpec()
        {
            var _dateCalculatorService = GetDateCalculatorService();
            var publicHolidays = new List<PublicHoliday>();

            publicHolidays.Add(new PublicHoliday("Queens Day", new DateTime(2022, 06, 01), false, true));

            var publicHolidayDates = _dateCalculatorService.GetPublicHolidayDates(publicHolidays);

            Assert.NotNull(publicHolidayDates);
            Assert.Equal(0, publicHolidayDates.Count);
        }
    }
}
