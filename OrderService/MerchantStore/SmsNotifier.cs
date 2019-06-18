using System;
using System.Threading.Tasks;

namespace OrderService.MerchantStore
{
    public class SmsNotifier : INotifier
    {
        private readonly string _msg;

        public SmsNotifier(string msg)
        {
            _msg = msg;
            // Read SMS Configuration settings for sending sms through http calls#
            // sms port, address, apiKey, apiSecret
        }
        public async Task SendNotification()
        {
            await Task.Delay(3000);
            //server checks if we have enough sms credit before sending  
            Console.ForegroundColor = ConsoleColor.Magenta;
           Console.WriteLine("SMS Sent:" + _msg);
           Console.ResetColor();
        }
    }
}