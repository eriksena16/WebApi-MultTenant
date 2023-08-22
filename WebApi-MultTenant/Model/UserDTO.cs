using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_MultTenant.Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
