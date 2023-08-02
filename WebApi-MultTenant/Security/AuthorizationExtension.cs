namespace WebApi_MultTenant.Security
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
        {
            return services.AddAuthorization(options =>
            {
                options.AddPolicy("ProdutoCadastro", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole("Admin");
                    builder.RequireClaim("Produto", "Cadastro");
                });
                options.AddPolicy("ContaCadastro", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole("Admin");
                    builder.RequireClaim("Conta", "Cadastro");
                });
                options.AddPolicy("UsuarioCadastro", builder =>
                {
                    builder.RequireAuthenticatedUser();
                    builder.RequireRole("Admin");
                    builder.RequireClaim("Usuario", "Cadastro");
                });

            });
        }
    }
}
