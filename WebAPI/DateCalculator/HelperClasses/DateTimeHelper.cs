namespace DateCalculator.HelperClasses
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// To check whether a day is weekday or not
        /// </summary>
        /// <param name="date">Input date</param>
        /// <returns>true -> if weekday, false -> if weekend</returns>
        public static bool IsWeekday(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
