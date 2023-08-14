using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Web_IdentityServer.Models;

namespace Web_IdentityServer.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ApplicationContext dbContext;

        public CoffeeShopService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CoffeeShopModel>> List()
        {
            var coffeeShops = await (from shop in dbContext.CoffeeShops
                                    select new CoffeeShopModel()
                                    {
                                        Id = shop.Id,
                                        Name = shop.Name,
                                        OpeningHours = shop.OpeningHours,
                                        Address = shop.Address
                                    }).ToListAsync();

            return coffeeShops;
        }
    }
}
