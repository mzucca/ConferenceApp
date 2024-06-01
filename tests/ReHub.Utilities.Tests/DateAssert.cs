using Xunit;

namespace ReHub.Utilities.Tests
{
    public static class DateAssert
    {
        public static void Equal(DateTime expected, DateTime actual, string message) =>
            Xunit.Assert.True(actual == expected && actual.Kind == expected.Kind, message);

        public static void Equal(DateTime expected, DateTime actual) =>
            Xunit.Assert.True(actual == expected && actual.Kind == expected.Kind);
    }
}
