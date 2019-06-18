using System.Threading.Tasks;

namespace OrderService.MerchantStore
{
    public interface INotifier
    {
        Task SendNotification();
    }
}