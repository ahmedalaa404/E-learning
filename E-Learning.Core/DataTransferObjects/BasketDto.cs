namespace E_Learning.Core.DataTransferObjects
{
    public class BasketDto
    {
        public string Id { get; set; }
        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }
        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
