using DateCalculator.HelperClasses;
using DateCalculator.Models;

namespace DateCalculator.Services
{
    public class DateCalculatorService : IDateCalculatorService
    {
        /// <summary>
        /// Get public holiday dates from a list of PublicHolidays
        /// </summary>
        /// <param name="publicHolidays">Public Holiday List</param>
        /// <returns>Public Holiday dates</returns>
        public IList<DateTime> GetPublicHolidayDates(IList<PublicHoliday> publicHolidays)
        {
            List<DateTime> publicHolidayDates = new List<DateTime>();

            foreach (var publicHoliday in publicHolidays)
            {
                if (!publicHoliday.IsSpecialHoliday)
                {
                    if (publicHoliday.Date.IsWeekday())
                    {
                        publicHolidayDates.Add(publicHoliday.Date);
                    }
                    else if(publicHoliday.IsHolidayGuranteed)
                    {
                        if (publicHoliday.Date.DayOfWeek == DayOfWeek.Saturday)
                        {
                            publicHolidayDates.Add(publicHoliday.Date.AddDays(2));
                        }
                        else if (publicHoliday.Date.DayOfWeek == DayOfWeek.Sunday)
                        {
                            publicHolidayDates.Add(publicHoliday.Date.AddDays(1));
                        }
                    }
                }

                else if (publicHoliday.IsSpecialHoliday && publicHoliday.SpecialPublicHoliday != null)
                {
                    var specialHolidayDate = GetSpecialHolidayDate(publicHoliday.Date, publicHoliday.SpecialPublicHoliday.Day, publicHoliday.SpecialPublicHoliday.Occurence);
                    publicHolidayDates.Add(specialHolidayDate);
                }
            }

            return publicHolidayDates;
        }

        /// <summary>
        /// Get date of Special Holiday
        /// </summary>
        /// <param name="date">Date of the holiday(main focus is year and month)</param>
        /// <param name="day">Day (eg. Monday, Tuesday... )</param>
        /// <param name="occurence">Occurence( e.g 2nd Monday, 5th Friday... )</param>
        /// <returns>Date of Special Holiday</returns>
        private DateTime GetSpecialHolidayDate(DateTime date, DayOfWeek day, int occurence)
        {
            while (date.DayOfWeek != day)
                date = date.AddDays(1);

            date = date.AddDays(7 * (occurence - 1));

            return date;
        } 
    }
}
