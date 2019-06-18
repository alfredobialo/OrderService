using System;
using System.Threading.Tasks;

namespace OrderService.AmazonServices
{
    public class PlaceOrder
    {
        private readonly ICustomerOrder _customerOrder;

        public PlaceOrder(ICustomerOrder customerOrder)
        {
            _customerOrder = customerOrder;
        }

        public async Task ProcessOrder(PlaceOrderCallback placeOrderCallback)
        {
            // Do the Processing Here
            _customerOrder.OrderId = Guid.NewGuid().ToString();
            _customerOrder.Total = 5600;
            await Task.Delay(2500);
            OrderProcessedMessage msg   =  new OrderProcessedMessage(_customerOrder,
                "Order was placed successfully", true);
            placeOrderCallback?.Invoke(msg);
        }
    }
}