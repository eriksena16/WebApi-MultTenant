namespace WebApi_MultTenant.Model
{
    public record UserLogin(long Id, long ContaId, string Nome, string Email, string ClienteSlug);
}
