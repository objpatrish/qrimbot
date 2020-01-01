using System.Threading.Tasks;
using Discord.WebSocket;

namespace objpatrishbot.Infrastructure.Interfaces
{
    public interface IMessageHandler <TMessage> where TMessage : SocketMessage
    {
        Task MessageReceived(TMessage message);
    }
}
