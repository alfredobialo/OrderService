using System;
using System.Threading.Tasks;

namespace OrderService.MerchantStore
{
    public class EmailNotifier  : INotifier
    {
        private readonly string _to;
        private readonly string _subj;
        private readonly string _body;
        private string from = "info@merchant-stores.com";
        public EmailNotifier(string to, string subj, string body)
        {
            _to = to;
            _subj = subj;
            _body = body;
            // read SMTP mail config
        }
        public async Task SendNotification()
        {
            await Task.Delay(2000);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Mail from :{from}" );
            Console.WriteLine($"Mail To :{_to}\n" );
            Console.WriteLine($"Mail Subject :{_subj}\n" );
            Console.WriteLine($"Mail Content :{_body}\n" );
            Console.ResetColor();
        }
    }
}