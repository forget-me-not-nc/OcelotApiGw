using System.Globalization;

namespace OrderAggregator.Extensions
{
    public static class DateUtils
    {
        public static string GetDateFormat() => "dd/MM/yyyy HH:mm:ss";
        public static CultureInfo GetDateProvider() => CultureInfo.InvariantCulture;
    }
}
