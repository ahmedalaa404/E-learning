using E_Learning.Core.Models.Basket;

namespace E_Learning.Core.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetCustomerBasketAsync(string id);
        Task<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket);
        Task<bool> DeleteCustomerBasketAsync(string id);
    }
}
