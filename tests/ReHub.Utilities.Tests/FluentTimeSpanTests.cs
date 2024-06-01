using ReHub.Utilities.Extensions;
using Xunit;

namespace ReHub.Utilities.Tests
{
    public class FluentTimeSpanTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(32)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public void Years_Months_Weeks_Days_Hours_Minutes_Seconds_Milliseconds_SimpleTests(int value)
        {
            Xunit.Assert.Equal(value.Years(), new(0, value, TimeSpan.Zero));
            Xunit.Assert.Equal(value.Months(), new(value, 0, TimeSpan.Zero));
            Xunit.Assert.Equal(value.Weeks(), new(0, 0, TimeSpan.FromDays(value * 7)));
            Xunit.Assert.Equal(value.Days(), new(0, 0, TimeSpan.FromDays(value)));
            Xunit.Assert.Equal(value.Hours(), new(0, 0, TimeSpan.FromHours(value)));
            Xunit.Assert.Equal(value.Minutes(), new(0, 0, TimeSpan.FromMinutes(value)));
            Xunit.Assert.Equal(value.Seconds(), new(0, 0, TimeSpan.FromSeconds(value)));
            Xunit.Assert.Equal(value.Milliseconds(), new(0, 0, TimeSpan.FromMilliseconds(value)));
            Xunit.Assert.Equal(value.Ticks(), new(0, 0, TimeSpan.FromTicks(value)));
        }

        [Fact]
        public void Subtract()
        {
            var halfDay = .5.Days();
            Xunit.Assert.Equal(3, 3.5.Days().Subtract(halfDay).Days);
            var timeSpan = new TimeSpan(3, 12, 0, 0);
            Xunit.Assert.Equal(3, timeSpan.SubtractFluentTimeSpan(halfDay).Days);
            Xunit.Assert.Equal(3, (timeSpan - halfDay).Days);
            Xunit.Assert.Equal(-3, (halfDay - timeSpan).Days);
        }

        [Fact]
        public void GetHashCodeTest() =>
            Xunit.Assert.Equal(343024320, 3.5.Days().GetHashCode());

        [Fact]
        public void CompareToFluentTimeSpan()
        {
            Xunit.Assert.Equal(0, 3.Days().CompareTo(3.Days()));
            Xunit.Assert.Equal(-1, 3.Days().CompareTo(4.Days()));
            Xunit.Assert.Equal(1, 4.Days().CompareTo(3.Days()));
        }

        [Fact]
        public void CompareToTimeSpan()
        {
            Xunit.Assert.Equal(0, 3.Days().CompareTo(TimeSpan.FromDays(3)));
            Xunit.Assert.Equal(-1, 3.Days().CompareTo(TimeSpan.FromDays(4)));
            Xunit.Assert.Equal(1, 4.Days().CompareTo(TimeSpan.FromDays(3)));
        }

        [Fact]
        public void CompareToObject()
        {
            Xunit.Assert.Equal(0, 3.Days().CompareTo((object)TimeSpan.FromDays(3)));
            Xunit.Assert.Equal(-1, 3.Days().CompareTo((object)TimeSpan.FromDays(4)));
            Xunit.Assert.Equal(1, 4.Days().CompareTo((object)TimeSpan.FromDays(3)));
        }

        [Fact]
        public void EqualsFluentTimeSpan()
        {
            Xunit.Assert.True(3.Days().Equals(3.Days()));
            Xunit.Assert.False(4.Days().Equals(3.Days()));
        }

        [Fact]
        public void EqualsTimeSpan()
        {
            Xunit.Assert.True(3.Days().Equals(TimeSpan.FromDays(3)));
            Xunit.Assert.False(4.Days().Equals(TimeSpan.FromDays(3)));
        }

        [Fact]
        public void AreEquals()
        {
            // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625
            Xunit.Assert.False(3.Days().Equals(null));
#pragma warning restore CS8625
        }

        [Fact]
        public void EqualsTimeSpanAsObject() =>
            Xunit.Assert.True(3.Days().Equals((object)TimeSpan.FromDays(3)));

        [Fact]
        public void EqualsObject() =>
            Xunit.Assert.False(3.Days().Equals(1));

        [Fact]
        public void Add()
        {
            var halfDay = .5.Days();
            Xunit.Assert.Equal(4, 3.5.Days().Add(halfDay).Days);
            var timeSpan = new TimeSpan(3, 12, 0, 0);
            Xunit.Assert.Equal(4, timeSpan.AddFluentTimeSpan(halfDay).Days);
            Xunit.Assert.Equal(4, (timeSpan + halfDay).Days);
            Xunit.Assert.Equal(4, (halfDay + timeSpan).Days);
        }

        [Fact]
        public void ToStringTest() =>
            Xunit.Assert.Equal("3.12:00:00", 3.5.Days().ToString());

        [Fact]
        public void Clone()
        {
            var timeSpan = 3.Milliseconds();
            var clone = timeSpan.Clone();
            Xunit.Assert.Equal(timeSpan, clone);
        }

        [Fact]
        public void Ticks() =>
            Xunit.Assert.Equal(30000, 3.Milliseconds().Ticks);

        [Fact]
        public void Milliseconds() =>
            Xunit.Assert.Equal(100, 1100.Milliseconds().Milliseconds);

        [Fact]
        public void TotalMilliseconds() =>
            Xunit.Assert.Equal(1100, 1100.Milliseconds().TotalMilliseconds);

        [Fact]
        public void Seconds() =>
            Xunit.Assert.Equal(1, 61.Seconds().Seconds);

        [Fact]
        public void TotalSeconds() =>
            Xunit.Assert.Equal(61, 61.Seconds().TotalSeconds);

        [Fact]
        public void Minutes() =>
            Xunit.Assert.Equal(1, 61.Minutes().Minutes);

        [Fact]
        public void TotalMinutes() =>
            Xunit.Assert.Equal(61, 61.Minutes().TotalMinutes);

        [Fact]
        public void Hours() =>
            Xunit.Assert.Equal(1, 25.Hours().Hours);

        [Fact]
        public void TotalHours() =>
            Xunit.Assert.Equal(25, 25.Hours().TotalHours);

        [Fact]
        public void Days() =>
            Xunit.Assert.Equal(366, 366.Days().Days);

        [Fact]
        public void TotalDays() =>
            Xunit.Assert.Equal(366, 366.Days().TotalDays);

        [Fact]
        public void Years()
        {
            var fluentTimeSpan = 3.Years();
            Xunit.Assert.Equal(3, fluentTimeSpan.Years);
        }

        [Fact]
        public void EnsureWhenConvertedIsCorrect()
        {
            TimeSpan timeSpan = 10.Years();
            Xunit.Assert.Equal(3650d, timeSpan.TotalDays);
        }

        public class OperatorOverloads
        {
            [Fact]
            public void LessThan()
            {
                Xunit.Assert.True(1.Seconds() < 2.Seconds());
                Xunit.Assert.True(1.Seconds() < TimeSpan.FromSeconds(2));
                Xunit.Assert.True(TimeSpan.FromSeconds(1) < 2.Seconds());
            }

            [Fact]
            public void LessThanOrEqualTo()
            {
                Xunit.Assert.True(1.Seconds() <= 2.Seconds());
                Xunit.Assert.True(1.Seconds() <= TimeSpan.FromSeconds(2));
                Xunit.Assert.True(TimeSpan.FromSeconds(1) <= 2.Seconds());
            }

            [Fact]
            public void GreaterThan()
            {
                Xunit.Assert.True(2.Seconds() > 1.Seconds());
                Xunit.Assert.True(2.Seconds() > TimeSpan.FromSeconds(1));
                Xunit.Assert.True(TimeSpan.FromSeconds(2) > 1.Seconds());
            }

            [Fact]
            public void GreaterThanOrEqualTo()
            {
                Xunit.Assert.True(2.Seconds() >= 1.Seconds());
                Xunit.Assert.True(2.Seconds() >= TimeSpan.FromSeconds(1));
                Xunit.Assert.True(TimeSpan.FromSeconds(2) >= 1.Seconds());
            }

            [Fact]
            public void AreEquals()
            {
                Xunit.Assert.True(2.Seconds() == 2.Seconds());
                Xunit.Assert.True(2.Seconds() == TimeSpan.FromSeconds(2));
                Xunit.Assert.True(TimeSpan.FromSeconds(2) == 2.Seconds());
            }

            [Fact]
            public void NotEquals()
            {
                Xunit.Assert.True(2.Seconds() != 1.Seconds());
                Xunit.Assert.True(2.Seconds() != TimeSpan.FromSeconds(1));
                Xunit.Assert.True(TimeSpan.FromSeconds(2) != 1.Seconds());
            }

            [Fact]
            public void Add()
            {
                Xunit.Assert.Equal(1.Seconds() + 2.Seconds(), 3.Seconds());
                Xunit.Assert.Equal(1.Seconds() + TimeSpan.FromSeconds(2), 3.Seconds());
                Xunit.Assert.Equal(TimeSpan.FromSeconds(1) + 2.Seconds(), 3.Seconds());
            }

            [Fact]
            public void Subtract()
            {
                Xunit.Assert.Equal(1.Seconds() - 2.Seconds(), -1.Seconds());
                Xunit.Assert.Equal(1.Seconds() - TimeSpan.FromSeconds(2), -1.Seconds());
                Xunit.Assert.Equal(TimeSpan.FromSeconds(1) - 2.Seconds(), -1.Seconds());
            }
        }

        public class ToDisplayStringTests
        {
            [Fact]
            public void DaysHours()
            {
                var timeSpan = 2.Days() + 3.Hours();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("2 days and 3 hours", displayString);
            }

            [Fact]
            public void DaysHoursRoundUp()
            {
                var timeSpan = 2.Days() + 3.Hours() + 30.Minutes();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("2 days and 4 hours", displayString);
            }

            [Fact]
            public void DaysHoursRoundDown()
            {
                var timeSpan = 2.Days() + 3.Hours() + 9.Minutes();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("2 days and 3 hours", displayString);
            }

            [Fact]
            public void HoursMinutes()
            {
                var timeSpan = 2.Hours() + 9.Minutes();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("2 hours and 9 minutes", displayString);
            }

            [Fact]
            public void HoursMinutesRoundUp()
            {
                var timeSpan = 2.Hours() + 9.Minutes() + 30.Seconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("2 hours and 10 minutes", displayString);
            }

            [Fact]
            public void HoursMinutesRoundDown()
            {
                var timeSpan = 2.Hours() + 9.Minutes() + 10.Seconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("2 hours and 9 minutes", displayString);
            }

            [Fact]
            public void MinutesSeconds()
            {
                var timeSpan = 9.Minutes();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("9 minutes and 0 seconds", displayString);
            }

            [Fact]
            public void MinutesSecondsRoundUp()
            {
                var timeSpan = 9.Minutes() + 30.5.Seconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("9 minutes and 31 seconds", displayString);
            }

            [Fact]
            public void MinutesSecondsRoundDown()
            {
                var timeSpan = 9.Minutes() + 30.4.Seconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("9 minutes and 30 seconds", displayString);
            }

            [Fact]
            public void SecondsMilliseconds()
            {
                var timeSpan = 9.Seconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("9 seconds", displayString);
            }

            [Fact]
            public void SecondsMillisecondsRoundUp()
            {
                var timeSpan = 9.Seconds() + 500.Milliseconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal(9.5 + " seconds", displayString);
            }

            [Fact]
            public void SecondsMillisecondsRoundDown()
            {
                var timeSpan = 9.Seconds() + 300.Milliseconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal(9.3 + " seconds", displayString);
            }

            [Fact]
            public void Milliseconds()
            {
                var timeSpan = 9.Milliseconds();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("9 milliseconds", displayString);
            }

            [Fact]
            public void ABitOverADay()
            {
                var timeSpan = 46.2.Hours();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("1 days and 22 hours", displayString);
            }

            [Fact]
            public void ABitOverADay2()
            {
                var timeSpan = 46.9.Hours();
                var displayString = timeSpan.ToDisplayString();
                Xunit.Assert.Equal("1 days and 23 hours", displayString);
            }
        }
    }
}
