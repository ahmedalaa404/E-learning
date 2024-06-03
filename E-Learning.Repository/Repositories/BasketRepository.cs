using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Models.Basket;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Learning.Repository.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly StackExchange.Redis.IDatabase _database;

        public BasketRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<bool> DeleteCustomerBasketAsync(string id)
         => await _database.KeyDeleteAsync(id);

        public async Task<CustomerBasket?> GetCustomerBasketAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket)
        {
            var serializedbasket = JsonSerializer.Serialize(basket);
            var result = await _database.StringSetAsync(basket.Id, serializedbasket, TimeSpan.FromDays(7));
            return result ? await GetCustomerBasketAsync(basket.Id) : null;
        }
    }
}
