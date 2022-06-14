﻿using DateCalculator.Models;
using DateCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace DateCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateCalculatorController : ControllerBase
    {
        private IDayCalculatorService _dayCalculatorService;
        public DateCalculatorController(IDayCalculatorService dayCalculatorService)
        {
            _dayCalculatorService = dayCalculatorService;
        }

        [HttpGet("/GetWeekdays/")]
        public int GetWeekdays(DateTime startDate, DateTime endDate)
        {
            try
            {
                var noOfDays = _dayCalculatorService.WeekdaysBetweenTwoDates(startDate, endDate);

                return noOfDays;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/GetBusinessDaysWithPublicHolidayDates/")]
        public int GetBusinessDays(DateTime startDate, DateTime endDate, string publicHolidays)
        {
            if (string.IsNullOrWhiteSpace(publicHolidays))
            {
                throw new Exception("Public Holidays List should not be empty");
            }

            try
            {
                var publicHolidayDates = new List<DateTime>();
                var arrPublicHolidays = publicHolidays.Split(',');
                foreach (var publicHoliday in arrPublicHolidays)
                {
                    publicHolidayDates.Add(Convert.ToDateTime(publicHoliday));
                }
                var noOfDays = _dayCalculatorService.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidayDates);

                return noOfDays;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("/GetBusinessDaysWithPublicHolidays/")]
        public int GetBusinessDays(DateTime startDate, DateTime endDate, [FromBody] IList<PublicHoliday> publicHolidays)
        {
            var noOfDays = _dayCalculatorService.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            return noOfDays;
        }

        [HttpGet("/GetBusinessDays/")]
        public int GetBusinessDays(DateTime startDate, DateTime endDate)
        {
            var publicHolidays = new List<PublicHoliday>();
            publicHolidays.Add(new PublicHoliday("Anzac Day", new DateTime(2022, 04, 25), false, false));
            publicHolidays.Add(new PublicHoliday("New Year", new DateTime(2022, 01, 01), true, false));
            publicHolidays.Add(new PublicHoliday("Queens Day", new DateTime(2018, 06, 01), false, true, new SpecialPublicHoliday(DayOfWeek.Monday, 2)));

            var noOfDays = _dayCalculatorService.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            return noOfDays;
        }
    }
}
