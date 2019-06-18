using System.Collections;
using System.Collections.Generic;

namespace OrderService.AmazonServices
{
    public interface ICustomerOrder
    {
        
        string OrderId { get; set; }
        
        string  CustomerName { get; set; }
        
        IEnumerable<string> Items { get; set; }
        
        decimal Total { get; set; }
    }

    public delegate void PlaceOrderCallback(IOrderCallback callback);

    public interface IOrderCallback
    { 
        ICustomerOrder CustomerOrder { get;  } 
        string Message { get; }
        bool Success { get; }
    }

    public sealed class OrderProcessedMessage : IOrderCallback
    {
        private ICustomerOrder _customerOrder;
        private string _message;
        private bool _success;

        public OrderProcessedMessage(ICustomerOrder customerOrder, string message, bool success)
        {
            _customerOrder = customerOrder;
            _message = message;
            _success = success;
        }

        ICustomerOrder IOrderCallback.CustomerOrder => _customerOrder;

        string IOrderCallback.Message => _message;

        bool IOrderCallback.Success => _success;
    }
}