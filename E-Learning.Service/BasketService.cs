using AutoMapper;
using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Repositories;
using E_Learning.Core.Interfaces.Services;
using E_Learning.Core.Models.Basket;

namespace E_Learning.Service
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<bool> DeleteBasketAsync(string id)
        => _repository.DeleteCustomerBasketAsync(id);

        public async Task<BasketDto?> GetBasketAsync(string id)
        {
            var basket = await _repository.GetCustomerBasketAsync(id);
            return basket is null ? null : _mapper.Map<BasketDto?>(basket);
        }

        public async Task<BasketDto?> UpdateBasketAsync(BasketDto basket)
        {
            var basketCustomer = _mapper.Map<CustomerBasket>(basket);
            var updateBasket = await _repository.UpdateCustomerBasketAsync(basketCustomer);
            return updateBasket is null ? null : _mapper.Map<BasketDto>(updateBasket);
        }
    }
}
