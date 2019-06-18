using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.AmazonServices;

namespace OrderService.MerchantStore
{
    public class StoreOrders : ICustomerOrder
    {
        public async Task PlaceCustomerOrder(Customer c)
        {
            // Items are 
            ((ICustomerOrder)this).CustomerName = c.FullName;
            ((ICustomerOrder)this).Items = new[] {"Galaxy S10", "iPhone X  Max","Huawei Mate 30 Pro"};
            AmazonServices.PlaceOrder order  =  new PlaceOrder(this);
            await order.ProcessOrder(async orderCallBack =>
            {
                string items = "";
                foreach (var item in orderCallBack.CustomerOrder.Items)
                {
                    items += item + "\n";
                }
                //orderCallBack.CustomerOrder.Items;
                // Create new Email Notification
                INotifier emailNotifier  = new EmailNotifier(c.EmailAddress,
                    $"Your Order of(NGN {orderCallBack.CustomerOrder.Total:N}) has been Placed Successfully",
                    $"Hi {c.FullName}, Thanks for your patronage\n Your Order of NGN {orderCallBack.CustomerOrder.Total:N} was successful\n" +
                    $"Order Id :{ orderCallBack.CustomerOrder.OrderId}\n" +
                    $"Items Ordered are : \n{items}");
                await emailNotifier.SendNotification();
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========== ORDER PLACE, You will Receive Notifications Shortly ================");
            Console.ResetColor();
        }

         string ICustomerOrder.OrderId { get; set; }
         string ICustomerOrder.CustomerName { get; set; }
         IEnumerable<string> ICustomerOrder.Items { get; set; }  =  new List<string>();
         decimal ICustomerOrder.Total { get; set; }
    }
}