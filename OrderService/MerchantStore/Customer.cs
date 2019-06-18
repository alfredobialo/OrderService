using OrderService.AmazonServices;

namespace OrderService.MerchantStore
{
    public class Customer 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}