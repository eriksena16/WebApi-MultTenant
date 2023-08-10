using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_MultTenant.Context;
using WebApi_MultTenant.Model;


namespace WebApi_MultTenant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ApiControllerBase
    {
        private readonly ContextoMaster _contextoMaster;
        public ClientesController(ContextoMaster contextoMaster) : base()
        {
            _contextoMaster = contextoMaster;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<List<Cliente>> Get()
        {
            return await _contextoMaster.Clientes.ToListAsync();
        }

        // GET api/<ClientesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClientesController>
        [HttpPost]
        public Cliente Post([FromBody] Cliente cliente)
        {
            _contextoMaster.Clientes.Add(cliente);
            _contextoMaster.SaveChanges();

            return cliente;
        }


    }
}
