using Xunit;
using ReHub.Utilities.Extensions;
using System.Globalization;

namespace ReHub.Utilities.Tests
{
    public class DateTimeOffsetTests
    {
        const int DaysPerWeek = 7;

        [Fact]
        public void AddFluentTimeSpan()
        {
            var originalPointInTime = new DateTimeOffset(1976, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var fluentTimeSpan = 1.Months();
            originalPointInTime.AddFluentTimeSpan(fluentTimeSpan);
            Xunit.Assert.Equal(new(1976, 2, 1, 0, 0, 0, TimeSpan.Zero), originalPointInTime.AddFluentTimeSpan(fluentTimeSpan));
        }

        [Fact]
        public void SubtractFluentTimeSpan()
        {
            var originalPointInTime = new DateTimeOffset(1976, 2, 1, 0, 0, 0, TimeSpan.Zero);
            var fluentTimeSpan = 1.Months();
            Xunit.Assert.Equal(new(1976, 1, 1, 0, 0, 0, TimeSpan.Zero), originalPointInTime.SubtractFluentTimeSpan(fluentTimeSpan));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(32)]
        [InlineData(40)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public void Ago_FromFixedDateTime_Tests(int agoValue)
        {
            var originalPointInTime = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(agoValue.Years().Before(originalPointInTime), originalPointInTime.AddYears(-agoValue));
            Xunit.Assert.Equal(agoValue.Months().Before(originalPointInTime), originalPointInTime.AddMonths(-agoValue));
            Xunit.Assert.Equal(agoValue.Weeks().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue * DaysPerWeek));
            Xunit.Assert.Equal(agoValue.Days().Before(originalPointInTime), originalPointInTime.AddDays(-agoValue));

            Xunit.Assert.Equal(agoValue.Hours().Before(originalPointInTime), originalPointInTime.AddHours(-agoValue));
            Xunit.Assert.Equal(agoValue.Minutes().Before(originalPointInTime), originalPointInTime.AddMinutes(-agoValue));
            Xunit.Assert.Equal(agoValue.Seconds().Before(originalPointInTime), originalPointInTime.AddSeconds(-agoValue));
            Xunit.Assert.Equal(agoValue.Milliseconds().Before(originalPointInTime), originalPointInTime.AddMilliseconds(-agoValue));
            Xunit.Assert.Equal(agoValue.Ticks().Before(originalPointInTime), originalPointInTime.AddTicks(-agoValue));
        }

        [Fact]
        public void Ago_FromOneMonth()
        {
            var originalPointInTime = new DateTimeOffset(1976, 4, 30, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(1.Months().Before(originalPointInTime), new(1976, 3, 30, 0, 0, 0, TimeSpan.Zero));
            Xunit.Assert.Equal(1.Months().From(originalPointInTime), new(1976, 5, 30, 0, 0, 0, TimeSpan.Zero));
        }

        [Fact]
        public void Ago_FromOneYearLeap()
        {
            var originalPointInTime = new DateTimeOffset(2004, 2, 29, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(1.Years().Before(originalPointInTime), new(2003, 2, 28, 0, 0, 0, TimeSpan.Zero));
            Xunit.Assert.Equal(1.Years().From(originalPointInTime), new(2005, 2, 28, 0, 0, 0, TimeSpan.Zero));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(32)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public void From_FromFixedDateTime_Tests(int value)
        {
            var originalPointInTime = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(value.Years().From(originalPointInTime), originalPointInTime.AddYears(value));
            Xunit.Assert.Equal(value.Months().From(originalPointInTime), originalPointInTime.AddMonths(value));
            Xunit.Assert.Equal(value.Weeks().From(originalPointInTime), originalPointInTime.AddDays(value * DaysPerWeek));
            Xunit.Assert.Equal(value.Days().From(originalPointInTime), originalPointInTime.AddDays(value));

            Xunit.Assert.Equal(value.Hours().From(originalPointInTime), originalPointInTime.AddHours(value));
            Xunit.Assert.Equal(value.Minutes().From(originalPointInTime), originalPointInTime.AddMinutes(value));
            Xunit.Assert.Equal(value.Seconds().From(originalPointInTime), originalPointInTime.AddSeconds(value));
            Xunit.Assert.Equal(value.Milliseconds().From(originalPointInTime), originalPointInTime.AddMilliseconds(value));
            Xunit.Assert.Equal(value.Ticks().From(originalPointInTime), originalPointInTime.AddTicks(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(23)]
        public void ChangeTime_Hour_SimpleTests(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            var result = toChange.SetTime(value);
            var expected = new DateTimeOffset(2008, 10, 25, value, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(24)]
        [InlineData(-1)]
        public void ChangeTime_Hour_SimpleTests_Arg_Checks(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                toChange.SetTime(value);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(16)]
        [InlineData(59)]
        public void ChangeTime_Minute_SimpleTests(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(new(2008, 10, 25, 0, value, 0, 0, TimeSpan.Zero), toChange.SetTime(0, value));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(60)]
        public void ChangeTime_Minute_SimpleTests_Arg_Checks(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                toChange.SetTime(0, value);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(16)]
        [InlineData(59)]
        public void ChangeTime_Second_SimpleTests(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            var changed = toChange.SetTime(0, 0, value);


            var expected = new DateTimeOffset(2008, 10, 25, 0, 0, value, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(expected, changed);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(60)]
        public void ChangeTime_Second_SimpleTests_Arg_Checks(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                toChange.SetTime(0, 0, value);
            });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(999)]
        public void ChangeTime_Millisecond_SimpleTests(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);

            Xunit.Assert.Equal(new(2008, 10, 25, 0, 0, 0, value, TimeSpan.Zero), toChange.SetTime(0, 0, 0, value));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1000)]
        public void ChangeTime_Millisecond_SimpleTests_Arg_Checks(int value)
        {
            var toChange = new DateTimeOffset(2008, 10, 25, 0, 0, 0, 0, TimeSpan.Zero);
            Xunit.Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                toChange.SetTime(0, 0, 0, value);
            });
        }

        [Fact]
        public void BasicTests()
        {
            var now = DateTimeOffset.UtcNow;
            var expected = new DateTimeOffset(now.Year, now.Month, now.Day, 23, 59, 59, 999, TimeSpan.Zero);
            var actual = now.EndOfDay();
            Xunit.Assert.Equal(expected, actual);
            Xunit.Assert.Equal(new(now.Year, now.Month, now.Day, 0, 0, 0, 0, TimeSpan.Zero), now.BeginningOfDay());

            var firstBirthDay = new DateTimeOffset(1977, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);
            Xunit.Assert.Equal(firstBirthDay + new TimeSpan(1, 0, 5, 0, 0), firstBirthDay + 1.Days() + 5.Minutes());

            Xunit.Assert.Equal(now + TimeSpan.FromDays(1), now.NextDay());
            Xunit.Assert.Equal(now - TimeSpan.FromDays(1), now.PreviousDay());

            Xunit.Assert.Equal(now + TimeSpan.FromDays(7), now.WeekAfter());
            Xunit.Assert.Equal(now - TimeSpan.FromDays(7), now.WeekEarlier());

            Xunit.Assert.Equal(new(2009, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2008, 12, 31, 0, 0, 0, TimeSpan.Zero).Add(1.Days()));
            Xunit.Assert.Equal(new(2009, 1, 2, 0, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 1, 1, 0, 0, 0, 0, TimeSpan.Zero).Add(1.Days()));

            var sampleDate = new DateTimeOffset(2009, 1, 1, 13, 0, 0, 0, TimeSpan.Zero);
            Xunit.Assert.Equal(new(2009, 1, 1, 12, 0, 0, 0, TimeSpan.Zero), sampleDate.Noon());
            Xunit.Assert.Equal(new(2009, 1, 1, 0, 0, 0, 0, TimeSpan.Zero), sampleDate.Midnight());

            Xunit.Assert.Equal(3.Days() + 3.Days(), 6.Days());
            Xunit.Assert.Equal(102.Days() - 3.Days(), 99.Days());

            Xunit.Assert.Equal(24.Hours(), 1.Days());

            sampleDate = new(2008, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            Xunit.Assert.Equal(3.Days().Since(sampleDate), sampleDate + 3.Days());

            var saturday = new DateTimeOffset(2008, 10, 25, 12, 0, 0, TimeSpan.Zero);
            Xunit.Assert.Equal(new(2008, 11, 1, 12, 0, 0, TimeSpan.Zero), saturday.Next(DayOfWeek.Saturday));

            Xunit.Assert.Equal(new(2008, 10, 18, 12, 0, 0, TimeSpan.Zero), saturday.Previous(DayOfWeek.Saturday));

            var nextWeek = DateTimeOffset.UtcNow + 1.Weeks();

            var tomorrow = DateTimeOffset.UtcNow + 1.Days();
            var yesterday = DateTimeOffset.UtcNow - 1.Days();
            var changedHourTo14H = DateTimeOffset.UtcNow.SetHour(14);
            var todayNoon = DateTimeOffset.UtcNow.Noon();
            var tomorrowNoon = DateTimeOffset.UtcNow.NextDay().Noon();
            var fiveDaysAgo = TimeSpanOffsetExtensions.Ago(5.Days());
            var twoDaysFromNow = TimeSpanOffsetExtensions.FromNow(2.Days());
            var nextYearSameDateAsTodayNoon = TimeSpanOffsetExtensions.FromNow(1.Years()).Noon();

            var twoWeeksFromNow = TimeSpanOffsetExtensions.FromNow(2.Weeks());
        }

        [Fact]
        public void NextYear_ReturnsTheSameDateButNextYear()
        {
            var birthday = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);
            var nextYear = birthday.NextYear();
            Xunit.Assert.Equal(new(1977, 12, 31, 17, 0, 0, 0, TimeSpan.Zero), nextYear);
        }

        [Fact]
        public void PreviousYear_ReturnsTheSameDateButPreviousYear()
        {
            var birthday = new DateTimeOffset(1976, 12, 31, 17, 0, 0, 0, TimeSpan.Zero);
            var previousYear = birthday.PreviousYear();
            Xunit.Assert.Equal(new(1975, 12, 31, 17, 0, 0, 0, TimeSpan.Zero), previousYear);
        }

        [Fact]
        public void NextYear_IfNextYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthNextYear()
        {
            var someBirthday = new DateTimeOffset(2008, 2, 29, 17, 0, 0, 0, TimeSpan.Zero);
            var nextYear = someBirthday.NextYear();
            Xunit.Assert.Equal(new(2009, 3, 1, 17, 0, 0, 0, TimeSpan.Zero), nextYear);
        }

        [Fact]
        public void PreviousYear_IfPreviousYearDoesNotHaveTheSameDayInTheSameMonthThenCalculateHowManyDaysIsMissingAndAddThatToTheLastDayInTheSameMonthPreviousYear()
        {
            var someBirthday = new DateTimeOffset(2012, 2, 29, 17, 0, 0, 0, TimeSpan.Zero);
            var previousYear = someBirthday.PreviousYear();
            Xunit.Assert.Equal(new(2011, 3, 1, 17, 0, 0, 0, TimeSpan.Zero), previousYear);
        }

        [Fact]
        public void Next_ReturnsNextFridayProperly()
        {
            var friday = new DateTimeOffset(2009, 7, 10, 1, 0, 0, 0, TimeSpan.Zero);
            var reallyNextFriday = new DateTimeOffset(2009, 7, 17, 1, 0, 0, 0, TimeSpan.Zero);
            var nextFriday = friday.Next(DayOfWeek.Friday);

            Xunit.Assert.Equal(reallyNextFriday, nextFriday);
        }

        [Fact]
        public void Next_ReturnsPreviousFridayProperly()
        {
            var friday = new DateTimeOffset(2009, 7, 17, 1, 0, 0, 0, TimeSpan.Zero);
            var reallyPreviousFriday = new DateTimeOffset(2009, 7, 10, 1, 0, 0, 0, TimeSpan.Zero);
            var previousFriday = friday.Previous(DayOfWeek.Friday);

            Xunit.Assert.Equal(reallyPreviousFriday, previousFriday);
        }

        [Fact]
        public void IsBefore_ReturnsTrueForGivenDateThatIsInTheFuture()
        {
            // arrange
            var toCompareWith = DateTimeOffset.UtcNow + 1.Days();

            // Xunit.Assert
            Xunit.Assert.True(DateTimeOffset.UtcNow.IsBefore(toCompareWith));
        }

        [Fact]
        public void IsBefore_ReturnsFalseForGivenDateThatIsSame()
        {
            // arrange
            var toCompareWith = DateTimeOffset.UtcNow;

            // Xunit.Assert
            Xunit.Assert.False(toCompareWith.IsBefore(toCompareWith));
        }

        [Fact]
        public void IsAfter_ReturnsTrueForGivenDateThatIsInThePast()
        {
            // arrange
            var toCompareWith = DateTimeOffset.UtcNow - 1.Days();

            // Xunit.Assert
            Xunit.Assert.True(DateTimeOffset.UtcNow.IsAfter(toCompareWith));
        }

        [Fact]
        public void IsAfter_ReturnsFalseForGivenDateThatIsSame()
        {
            // arrange
            var toCompareWith = DateTimeOffset.UtcNow;

            // Xunit.Assert
            Xunit.Assert.False(toCompareWith.IsAfter(toCompareWith));
        }

        [Fact]
        public void At_SetsHourAndMinutesProperly() =>
            Xunit.Assert.Equal(new(2002, 12, 17, 18, 06, 01, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).At(18, 06));

        [Fact]
        public void At_SetsHourAndMinutesAndSecondsProperly() =>
            Xunit.Assert.Equal(new(2002, 12, 17, 18, 06, 02, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).At(18, 06, 02));

        [Fact]
        public void At_SetsHourAndMinutesAndMillisecondsProperly() =>
            Xunit.Assert.Equal(new(2002, 12, 17, 18, 06, 02, 03, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).At(18, 06, 02, 03));

        [Fact]
        public void PreviousQuarter_FirstDay_SetsTheDayToOne()
        {
            var expected = new DateTimeOffset(2001, 10, 1, 3, 5, 6, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), 1.Quarters().Ago(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay()));
        }

        [Fact]
        public void PreviousQuarter_LastDay_SetsTheDayToLastDayOfQuarter()
        {
            var expected = new DateTimeOffset(2001, 12, 31, 3, 5, 6, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), 1.Quarters().Ago(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay()));
        }

        [Fact]
        public void NextQuarter_FirstDay_SetsTheDayToOne()
        {
            var expected = new DateTimeOffset(2002, 4, 1, 3, 5, 6, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), 1.Quarters().From(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay()));
        }

        [Fact]
        public void NextQuarter_LastDay_SetsTheDayToLastDayOfQuarter()
        {
            var expected = new DateTimeOffset(2002, 6, 30, 3, 5, 6, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), 1.Quarters().From(new DateTimeOffset(2002, 1, 10, 4, 5, 6, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay()));
        }

        [Fact]
        public void FirstDayOfQuarter_SetsTheDayToOne()
        {
            var expected = new DateTimeOffset(2002, 1, 1, 6, 3, 0, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), new DateTimeOffset(2002, 3, 22, 12, 12, 12, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay());
        }

        [Fact]
        public void LastDayOfQuarter_SetsTheDayToLastDayInThatQuarter()
        {
            var expected = new DateTimeOffset(2002, 3, 31, 6, 3, 0, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), new DateTimeOffset(2002, 3, 22, 12, 12, 12, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay());
        }

        [Fact]
        public void FirstDayOfQuarter_Q4_SetsDayToFirstDay()
        {
            var expected = new DateTimeOffset(2002, 10, 1, 7, 8, 9, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), new DateTimeOffset(2002, 11, 22, 12, 12, 12, TimeSpan.Zero).FirstDayOfQuarter().BeginningOfDay());
        }

        [Fact]
        public void LastDayOfQuarter_Q4_SetsTheDayToLastDayOfQuarter()
        {
            var expected = new DateTimeOffset(2002, 12, 31, 4, 5, 6, TimeSpan.Zero);
            Xunit.Assert.Equal(expected.BeginningOfDay(), new DateTimeOffset(2002, 11, 22, 12, 12, 12, TimeSpan.Zero).LastDayOfQuarter().BeginningOfDay());
        }

        [Fact]
        public void FirstDayOfMonth_SetsTheDayToOne() =>
            Xunit.Assert.Equal(new(2002, 12, 1, 17, 05, 01, TimeSpan.Zero), new DateTimeOffset(2002, 12, 17, 17, 05, 01, TimeSpan.Zero).FirstDayOfMonth());

        [Fact]
        public void LastDayOfMonth_SetsTheDayToLastDayInThatMonth() =>
            Xunit.Assert.Equal(new(2002, 1, 31, 17, 05, 01, TimeSpan.Zero), new DateTimeOffset(2002, 1, 1, 17, 05, 01, TimeSpan.Zero).LastDayOfMonth());

        [Fact]
        public void AddBusinessDays_AdsDaysProperlyWhenThereIsWeekendAhead() =>
            Xunit.Assert.Equal(new(2009, 7, 13, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 9, 0, 0, 0, TimeSpan.Zero).AddBusinessDays(2));

        [Fact]
        public void AddBusinessDays_Negative() =>
            Xunit.Assert.Equal(new(2009, 7, 9, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 13, 0, 0, 0, TimeSpan.Zero).AddBusinessDays(-2));

        [Fact]
        public void SubtractBusinessDays_SubtractsDaysProperlyWhenThereIsWeekend() =>
            Xunit.Assert.Equal(new(2009, 7, 9, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 13, 0, 0, 0, TimeSpan.Zero).SubtractBusinessDays(2));

        [Fact]
        public void SubtractBusinessDays_Negative() =>
            Xunit.Assert.Equal(new(2009, 7, 13, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2009, 7, 9, 0, 0, 0, TimeSpan.Zero).SubtractBusinessDays(-2));

        [Fact]
        public void IsInFuture()
        {
            var now = DateTimeOffset.UtcNow;
            Xunit.Assert.False(now.Subtract(2.Seconds()).IsInFuture());
            Xunit.Assert.False(now.IsInFuture());
            Xunit.Assert.True(now.Add(2.Seconds()).IsInFuture());
        }

        [Fact]
        public void IsInPast()
        {
            var now = DateTimeOffset.UtcNow;
            Xunit.Assert.True(now.Subtract(2.Seconds()).IsInPast());
            Xunit.Assert.False(now.Add(2.Seconds()).IsInPast());
        }

        [Theory]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(30)]
        public void FirstDayOfWeek_FirstDayOfWeekIsMonday(int value)
        {
            var ci = Thread.CurrentThread.CurrentCulture;
            var currentCulture = new CultureInfo("en-AU")
            {
                DateTimeFormat =
            {
                FirstDayOfWeek = DayOfWeek.Monday
            }
            };
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Xunit.Assert.Equal(new(2011, 1, 24, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, value, 0, 0, 0, TimeSpan.Zero).FirstDayOfWeek());
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [Theory]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        public void FirstDayOfWeek_FirstDayOfWeekIsSunday(int value)
        {
            var ci = Thread.CurrentThread.CurrentCulture;
            var currentCulture = new CultureInfo("en-AU")
            {
                DateTimeFormat =
            {
                FirstDayOfWeek = DayOfWeek.Sunday
            }
            };
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Xunit.Assert.Equal(new(2011, 1, 23, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2011, 1, value, 0, 0, 0, TimeSpan.Zero).FirstDayOfWeek());
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [Theory]
        [InlineData("2011-06-22T06:40:20.005 +00:00")]
        [InlineData("2011-12-31T06:40:20.005 +00:00")]
        [InlineData("2011-01-01T06:40:20.005 +00:00")]
        public void FirstDayOfYear_BasicTest(string value)
        {
            var expected = new DateTimeOffset(2011, 1, 1, 6, 40, 20, 5, TimeSpan.Zero);
            Xunit.Assert.Equal(expected, DateTimeOffset.Parse(value).FirstDayOfYear());
        }

        [Theory]
        [InlineData("2011-12-24T06:40:20.005 +00:00")]
        [InlineData("2011-12-19T06:40:20.005 +00:00")]
        [InlineData("2011-12-25T06:40:20.005 +00:00")]
        public void LastDayOfWeek_BasicTest(string value)
        {
            var ci = Thread.CurrentThread.CurrentCulture;
            var currentCulture = new CultureInfo("en-AU")
            {
                DateTimeFormat =
            {
                FirstDayOfWeek = DayOfWeek.Monday
            }
            };
            Thread.CurrentThread.CurrentCulture = currentCulture;
            var expected = new DateTimeOffset(2011, 12, 25, 06, 40, 20, 5, TimeSpan.Zero);
            Xunit.Assert.Equal(expected, DateTimeOffset.Parse(value).LastDayOfWeek());
            Thread.CurrentThread.CurrentCulture = ci;
        }

        [Theory]
        [InlineData("2011-02-13T06:40:20.005 +00:00")]
        [InlineData("2011-01-01T06:40:20.005 +00:00")]
        [InlineData("2011-12-31T06:40:20.005 +00:00")]
        public void LastDayOfYear_BasicTest(string value)
        {
            var expected = new DateTimeOffset(2011, 12, 31, 06, 40, 20, 5, TimeSpan.Zero);
            Xunit.Assert.Equal(expected, DateTimeOffset.Parse(value).LastDayOfYear());
        }

        [Fact]
        public void PreviousMonth_BasicTest()
        {
            var expected = new DateTimeOffset(2009, 12, 20, 06, 40, 20, 5, TimeSpan.Zero);
            Xunit.Assert.Equal(expected, new DateTimeOffset(2010, 1, 20, 06, 40, 20, 5, TimeSpan.Zero).PreviousMonth());
        }

        [Fact]
        public void PreviousMonth_PreviousMonthDoesntHaveThatManyDays() =>
            Xunit.Assert.Equal(new(2009, 2, 28, 06, 40, 20, 5, TimeSpan.Zero), new DateTimeOffset(2009, 3, 31, 06, 40, 20, 5, TimeSpan.Zero).PreviousMonth());

        [Fact]
        public void NextMonth_BasicTest() =>
            Xunit.Assert.Equal(new(2013, 1, 5, 06, 40, 20, 5, TimeSpan.Zero), new DateTimeOffset(2012, 12, 5, 06, 40, 20, 5, TimeSpan.Zero).NextMonth());

        [Fact]
        public void PreviousMonth_NextMonthDoesntHaveThatManyDays() =>
            Xunit.Assert.Equal(new(2013, 2, 28, 06, 40, 20, 5, TimeSpan.Zero), new DateTimeOffset(2013, 1, 31, 06, 40, 20, 5, TimeSpan.Zero).NextMonth());
    }
}
