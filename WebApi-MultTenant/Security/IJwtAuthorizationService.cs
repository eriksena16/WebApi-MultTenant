using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Security
{
    public interface IJwtAuthorizationService
    {
        Task<string> Generate(UserLogin user);
    }
}
