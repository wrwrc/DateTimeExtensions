using System;

namespace DateTimeExtensions
{
    /// <inheritdoc cref="IEquatable{DateTimeRange}" />
    public struct DateTimeRange : IEquatable<DateTimeRange>
    {
        public readonly DateTime Start;

        public readonly DateTime End;

        public readonly bool IsMoment;

        public DateTimeRange(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new ArgumentException("end time before start time");
            }

            this.Start = start;
            this.End = end;
            this.IsMoment = start == end;
        }

        public static bool operator ==(DateTimeRange r1, DateTimeRange r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(DateTimeRange r1, DateTimeRange r2)
        {
            return !r1.Equals(r2);
        }

        public static DateTimeRange FromSecond(int year, int month, int day, int hour, int minute, int second)
        {
            var start = new DateTime(year, month, day, hour, minute, second);
            var range = new DateTimeRange(start, start.EndOfSecond());
            return range;
        }

        public static DateTimeRange FromMinute(int year, int month, int day, int hour, int minute)
        {
            var start = new DateTime(year, month, day, hour, minute, 0);
            var range = new DateTimeRange(start, start.EndOfMinute());
            return range;
        }

        public static DateTimeRange FromHour(int year, int month, int day, int hour)
        {
            var start = new DateTime(year, month, day, hour, 0, 0);
            var range = new DateTimeRange(start, start.EndOfHour());
            return range;
        }

        public static DateTimeRange FromDate(int year, int month, int day)
        {
            var start = new DateTime(year, month, day);
            var range = new DateTimeRange(start, start.EndOfDay());
            return range;
        }

        public static DateTimeRange FromMonth(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var range = new DateTimeRange(
                start,
                start.EndOfMonth());
            return range;
        }

        public static DateTimeRange FromYear(int year)
        {
            var range = new DateTimeRange(
                new DateTime(year, 1, 1),
                new DateTime(year + 1, 1, 1).AddTicks(-1));
            return range;
        }

        public bool Contains(DateTime moment)
        {
            return this.Start <= moment && this.End >= moment;
        }

        public bool Contains(DateTimeRange that)
        {
            return this.Start <= that.Start && this.End >= that.End;
        }

        public bool Intersects(DateTimeRange that)
        {
            return this.Start <= that.End && this.End >= that.Start;
        }

        public bool Equals(DateTimeRange other)
        {
            return this.Start == other.Start &&
                this.End == other.End;
        }

        public override bool Equals(object obj)
        {
            return obj is DateTimeRange range && this.Equals(range);
        }

        public override int GetHashCode()
        {
            return (13 * this.Start.GetHashCode()) + this.End.GetHashCode();
        }

        public override string ToString()
        {
            return this.Start + " - " + this.End;
        }
    }
}
