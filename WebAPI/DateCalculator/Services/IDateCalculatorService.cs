using DateCalculator.Models;

namespace DateCalculator.Services
{
    public interface IDateCalculatorService
    {
        IList<DateTime> GetPublicHolidayDates(IList<PublicHoliday> publicHolidays);
    }
}
