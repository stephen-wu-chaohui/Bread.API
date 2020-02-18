using Bread.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Bread.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
