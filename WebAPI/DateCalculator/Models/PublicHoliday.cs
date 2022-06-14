namespace DateCalculator.Models
{
    public class PublicHoliday
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsHolidayGuranteed { get; set; }
        public bool IsSpecialHoliday { get; set; }
        public SpecialPublicHoliday? SpecialPublicHoliday { get; set; }

        public PublicHoliday(string name,DateTime date, bool isHolidayGuranteed, bool isSpecialHoliday, SpecialPublicHoliday? specialPublicHoliday = null)
        {
            Name = name;
            Date = date;
            IsHolidayGuranteed = isHolidayGuranteed;
            IsSpecialHoliday = isSpecialHoliday;
            SpecialPublicHoliday = specialPublicHoliday;
        }
    }
}
