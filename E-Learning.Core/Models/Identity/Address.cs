namespace E_Learning.Core.Models.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public AppUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}