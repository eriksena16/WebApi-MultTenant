using Web_IdentityServer.Models;

namespace Web_IdentityServer.Services
{
    public interface ICoffeeShopService
    {
        Task<List<CoffeeShopModel>> List();
    }
}
