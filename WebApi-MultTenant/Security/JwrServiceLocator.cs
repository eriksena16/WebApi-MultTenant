namespace WebApi_MultTenant.Security
{
    public static class JwrServiceLocator
    {
        public static void CofigureJwtService(this IServiceCollection services)
        {
            services.AddScoped<IJwtAuthotizationService, JwtAuthorizationService>();
        }
    }
}
