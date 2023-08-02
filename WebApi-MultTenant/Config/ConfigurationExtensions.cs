namespace WebApi_MultTenant.Config
{
    public static class ConfigurationExtensions
    {
        public static string GetClientConnectionString(this IConfiguration configuration, string clientName)
        {
            // To make things easier we used a replace variable in the connection string and
            // we just replace with the client slug as a pattern.
            var connString = configuration.GetConnectionString("EstoqueConnection")
                .Replace("__DBNAME__", $"MultiTenant_{clientName}");

            return connString;
        }
    }
}
