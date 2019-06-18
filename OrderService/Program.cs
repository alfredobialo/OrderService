using System;
using OrderService.MerchantStore;

namespace OrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Customer  cc=   new Customer()
            {
                EmailAddress = "obafemikazeem@gmail.com",
                FirstName = "Obafemi",
                LastName = "Kazeem",
                Id = "obafemikazeem"
                
            };

        // Merchant Store
            var store  =   new MerchantStore.StoreOrders(); 
            Console.WriteLine($"{cc.FullName} Order processing started!!");
            store.PlaceCustomerOrder(cc).GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}