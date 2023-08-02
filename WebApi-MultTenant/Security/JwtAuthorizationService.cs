using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Security
{
    public class JwtAuthorizationService : IJwtAuthotizationService
    {
        public Task<string> Generate(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
