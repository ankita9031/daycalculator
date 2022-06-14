using DateCalculator.Services;

namespace DateCalulator.unittest.Services
{
    public class DayCalculatorServiceTests
    {
        private IDateCalculatorService dateCalculatorService;
        public DayCalculatorService GetDayCalculatorService()
        {
            return new DayCalculatorService(dateCalculatorService);
        }

        [Fact]
        public void WeekdaysBetweenTwoDates_EndDateLesserThanStartDate()
        {
            var dayCalculatorServcie = GetDayCalculatorService();
            var noOfDays = dayCalculatorServcie.WeekdaysBetweenTwoDates(new DateTime(2022, 01, 01), new DateTime(2021, 01, 01));
            Assert.Equal(0, noOfDays);
        }

        [Fact]
        public void WeekdaysBetweenTwoDates_AllWeekdaysBetweenDates()
        {
            var dayCalculatorServcie = GetDayCalculatorService();
            var noOfDays = dayCalculatorServcie.WeekdaysBetweenTwoDates(new DateTime(2022, 06, 06), new DateTime(2022, 06, 10));
            Assert.Equal(3, noOfDays);
        }

        [Fact]
        public void WeekdaysBetweenTwoDates_NotAllWeekdaysBetweenDates()
        {
            var dayCalculatorServcie = GetDayCalculatorService();
            var noOfDays = dayCalculatorServcie.WeekdaysBetweenTwoDates(new DateTime(2022, 06, 02), new DateTime(2022, 06, 10));
            Assert.Equal(5, noOfDays);
        }

        [Fact]
        public void BusinessDaysBetweenTwoDates_WithNoPublicHolidaysDates()
        {
            var dayCalculatorServcie = GetDayCalculatorService();
            var noOfDays = dayCalculatorServcie.BusinessDaysBetweenTwoDates(new DateTime(2022, 06, 02), new DateTime(2022, 06, 10),new List<DateTime>());
            Assert.Equal(5, noOfDays);
        }
        [Fact]
        public void BusinessDaysBetweenTwoDates_WithNoPublicHolidaysDatesInBetween()
        {
            var dayCalculatorServcie = GetDayCalculatorService();
            var publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2022, 05, 03));
            var noOfDays = dayCalculatorServcie.BusinessDaysBetweenTwoDates(new DateTime(2022, 06, 02), new DateTime(2022, 06, 10), publicHolidays);
            Assert.Equal(5, noOfDays);
        }

        [Fact]
        public void BusinessDaysBetweenTwoDates_WithPublicHolidaysDatesInBetween()
        {
            var dayCalculatorServcie = GetDayCalculatorService();
            var publicHolidays = new List<DateTime>();
            publicHolidays.Add(new DateTime(2022, 06, 03));
            var noOfDays = dayCalculatorServcie.BusinessDaysBetweenTwoDates(new DateTime(2022, 06, 02), new DateTime(2022, 06, 10), publicHolidays);
            Assert.Equal(4, noOfDays);
        }
    }
}
