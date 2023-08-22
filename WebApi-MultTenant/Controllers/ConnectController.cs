using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApi_MultTenant.Context;
using WebApi_MultTenant.Model;
using WebApi_MultTenant.Security;

namespace WebApi_MultTenant.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ConnectController : ApiControllerBase
    {
        private readonly ContextoMaster _contextoMaster;
        private readonly IJwtAuthorizationService _jwtAuthorization;
        public ConnectController(ContextoMaster contextoMaster, IJwtAuthorizationService jwtAuthorization) : base()
        {
            _contextoMaster = contextoMaster;
            _jwtAuthorization = jwtAuthorization;
        }

        [HttpPost("token")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetToken([FromBody] UserDTO userDTO)
        {
            var user = _contextoMaster.Usuarios
                .Include(c => c.Conta).ThenInclude(c => c.Cliente)
                .Where(c => c.Email == userDTO.Email
                && c.Senha == userDTO.Senha)
                .FirstOrDefault();

            string token = string.Empty;

            if (user is Usuario)
            {
                UserLogin userLogin = new UserLogin(user.Id, user.ContaId, user.Nome, userDTO.Email, user.Conta?.Cliente?.Slug);
                token = await _jwtAuthorization.Generate(userLogin);
            }
            else
                throw new Exception("Usuario nao encontrado");

            return Ok(token);

        }


    }
}
