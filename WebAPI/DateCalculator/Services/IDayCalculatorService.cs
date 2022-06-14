using DateCalculator.Models;

namespace DateCalculator.Services
{
    public interface IDayCalculatorService
    {
        int WeekdaysBetweenTwoDates(DateTime startDate, DateTime endDate);

        int BusinessDaysBetweenTwoDates(DateTime startDate, DateTime endDate, IList<DateTime> publicHolidays);

        int BusinessDaysBetweenTwoDates(DateTime startDate, DateTime endDate, IList<PublicHoliday> publicHolidays);
    }
}
