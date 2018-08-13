using System;

namespace DateTimeExtensions
{
    public static class DateTimeHelper
    {
        public static DateTime StartOfSecond(this DateTime moment)
        {
            return new DateTime(moment.Year, moment.Month, moment.Day, moment.Hour, moment.Minute, moment.Second);
        }

        public static DateTime StartOfMinute(this DateTime moment)
        {
            return new DateTime(moment.Year, moment.Month, moment.Day, moment.Hour, moment.Minute, 0);
        }

        public static DateTime StartOfHour(this DateTime moment)
        {
            return new DateTime(moment.Year, moment.Month, moment.Day, moment.Hour, 0, 0);
        }

        public static DateTime StartOfWeek(this DateTime moment, DayOfWeek firstWeekDay = DayOfWeek.Sunday)
        {
            var dayDiff = (int)firstWeekDay - (int)moment.DayOfWeek;
            if (dayDiff > 0)
            {
                dayDiff -= 7;
            }

            return moment.Date.AddDays(dayDiff);
        }

        public static DateTime StartOfMonth(this DateTime moment)
        {
            return new DateTime(moment.Year, moment.Month, 1);
        }

        public static DateTime StartOfQuarter(this DateTime moment)
        {
            var quarterStartMonth = moment.Month - (moment.Month % 3) + 1;
            return new DateTime(moment.Year, quarterStartMonth, 1);
        }

        public static DateTime StartOfYear(this DateTime moment)
        {
            return new DateTime(moment.Year, 1, 1);
        }

        public static DateTime EndOfSecond(this DateTime moment)
        {
            return moment.StartOfSecond().AddSeconds(1).AddTicks(-1);
        }

        public static DateTime EndOfMinute(this DateTime moment)
        {
            return moment.StartOfMinute().AddMinutes(1).AddTicks(-1);
        }

        public static DateTime EndOfHour(this DateTime moment)
        {
            return moment.StartOfHour().AddHours(1).AddTicks(-1);
        }

        public static DateTime EndOfDay(this DateTime moment)
        {
            return moment.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTime EndOfWeek(this DateTime moment, DayOfWeek firstWeekDay = DayOfWeek.Sunday)
        {
            var dayDiff = (int)firstWeekDay - (int)moment.DayOfWeek;
            if (dayDiff <= 0)
            {
                dayDiff += 7;
            }

            return moment.Date.AddDays(dayDiff);
        }

        public static DateTime EndOfMonth(this DateTime moment)
        {
            return moment.StartOfMonth().AddMonths(1).AddTicks(-1);
        }

        public static DateTime EndOfYear(this DateTime moment)
        {
            return new DateTime(moment.Year + 1, 1, 1).AddTicks(-1);
        }

        public static DateTimeRange Until(this DateTime start, DateTime end)
        {
            return new DateTimeRange(start, end);
        }

        public static DateTimeRange Since(this DateTime end, DateTime start)
        {
            return new DateTimeRange(start, end);
        }
    }
}
