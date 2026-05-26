using System.Configuration;

namespace booking.Data
{
    internal static class DbConfig
    {
        internal static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
    }
}