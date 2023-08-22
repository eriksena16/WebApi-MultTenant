using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Security
{
    public class JwtAuthorizationService : IJwtAuthorizationService
    {
        private readonly BearerSecurityKey _bearerSecurityKey;
        private readonly IConfiguration _configuration;
        public JwtAuthorizationService(IOptionsMonitor<BearerSecurityKey> bearerSecurityKey, IConfiguration configuration)
        {
            _bearerSecurityKey = bearerSecurityKey.CurrentValue;
            _configuration = configuration;
        }
        public async Task<string> Generate(UserLogin user)
        {
            //string Jwt = Get<string>("BearerSecurityKey:JwtSecurityKey");
            //BearerSecurityKey bearerSecurity = Get<BearerSecurityKey>("BearerSecurityKey");


            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_bearerSecurityKey.JwtSecurityKey);
            //var key = Encoding.ASCII.GetBytes("ab197302-a31d-4ab9-a8c4-83a7a7c7928b");
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Produto", "Cadastro"),
                    new Claim("lastAccountId", user.ContaId.ToString()),
                    new Claim("slug", user.ClienteSlug),
                    new Claim("id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2), //tempo
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return await Task.FromResult(jwtSecurityTokenHandler.WriteToken(token));
        }

        public T Get<T>(string key)
        {
            return (T)Convert.ChangeType(this._configuration[key], typeof(T));
        }
    }
}
