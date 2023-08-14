using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_IdentityServer.Services;

namespace Web_IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ICoffeeShopService coffeeShopService;

        public CoffeeShopController(ICoffeeShopService coffeeShopService)
        {
            this.coffeeShopService = coffeeShopService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var coffeeShops = await coffeeShopService.List();
            return Ok(coffeeShops);
        }
    }
}
