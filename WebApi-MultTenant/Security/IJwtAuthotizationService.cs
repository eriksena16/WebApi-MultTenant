using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Security
{
    public interface IJwtAuthotizationService
    {
        Task<string> Generate(Usuario usuario);
    }
}
