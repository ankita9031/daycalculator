namespace DateCalculator.Models
{
    public class SpecialPublicHoliday
    {
        public DayOfWeek Day { get; set; }
        public int Occurence { get; set; }

        public SpecialPublicHoliday(DayOfWeek day, int occurence)
        {
            Day = day;
            Occurence = occurence;
        }
    }
}
