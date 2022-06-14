using DateCalculator.HelperClasses;
using DateCalculator.Models;

namespace DateCalculator.Services
{
    public class DayCalculatorService : IDayCalculatorService
    {
        private IDateCalculatorService _dateCalculatorService;
        public DayCalculatorService(IDateCalculatorService dateCalculatorService)
        {
            _dateCalculatorService = dateCalculatorService;
        }

        /// <summary>
        /// Calculate Business Days between two days with List of public holiday dates
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <param name="publicHolidays">List of Public Holiday Dates</param>
        /// <returns>No of Business Days</returns>
        public int BusinessDaysBetweenTwoDates(DateTime startDate, DateTime endDate, IList<DateTime> publicHolidays)
        {
            var noOfDays = GetNoOfDays(startDate, endDate, publicHolidays);

            return noOfDays;
        }

        /// <summary>
        /// Calculate Weekdays between two days
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns>No of Business Days</returns>
        public int WeekdaysBetweenTwoDates(DateTime startDate, DateTime endDate)
        {
            var noOfDays = GetNoOfDays(startDate, endDate);

            return noOfDays;
        }

        /// <summary>
        /// Calculate Business Days between two days with List of public holidays
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <param name="publicHolidays">List of Public Holidays</param>
        /// <returns>No of Business Days</returns>
        public int BusinessDaysBetweenTwoDates(DateTime startDate, DateTime endDate, IList<PublicHoliday> publicHolidays)
        {
            var publicHolidayDates = _dateCalculatorService.GetPublicHolidayDates(publicHolidays);

            var noOfDays = GetNoOfDays(startDate, endDate, publicHolidayDates);

            return noOfDays;
        }

        /// <summary>
        /// Calculate Business Days between two days with List of public holiday dates
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <param name="publicHolidays">List of Public Holiday Dates</param>
        /// <returns>No of Days</returns>
        private static int GetNoOfDays(DateTime startDate, DateTime endDate, IList<DateTime>? publicHolidayDates = null)
        {
            var noOfDays = 0;

            if (endDate <= startDate)
                return noOfDays; 

            for (var date = startDate.AddDays(1); date < endDate; date = date.AddDays(1))
            {
                if(date.IsWeekday())
                {
                    if (publicHolidayDates == null)
                    {
                        noOfDays++;
                    }
                    else if (publicHolidayDates != null && !publicHolidayDates.Contains(date))
                    {
                        noOfDays++;
                    }
                }
               
            }

            return noOfDays;
        }
    }
}
