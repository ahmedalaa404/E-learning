using E_Learning.Core.DataTransferObjects;

namespace E_Learning.Core.Interfaces.Services
{
    public interface IBasketService
    {
        Task<BasketDto?> GetBasketAsync(string id);
        Task<BasketDto?> UpdateBasketAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string id);
    }
}
