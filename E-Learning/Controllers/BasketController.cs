using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Interfaces.Services;
using E_Learning.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        [HttpGet]
        //[Cash(60)]
        public async Task<ActionResult<BasketDto>> Get(string id)
        {
            var basket = await _basketService.GetBasketAsync(id);
            return basket is null ? NotFound(new ApiResponse(404, $"Basket With Id {id} Not Found")) : Ok(basket);
        }


        [HttpPost]
        public async Task<ActionResult<BasketDto>> Update(BasketDto basketDTO)
        {
            var basket = await _basketService.UpdateBasketAsync(basketDTO);
            return basket is null ? NotFound(new ApiResponse(404, $"Basket With Id {basketDTO.Id} Not Found")) : Ok(basket);
        }


        [HttpDelete]
        public async Task<ActionResult<BasketDto>> Delete(string id)
            => Ok(await _basketService.DeleteBasketAsync(id));
    }
}
