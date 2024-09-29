using ChatAppApi.Model;
using ChatAppApi.ViewModels;

namespace ChatAppApi.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<MessageDto>> GetMessagesByConversationIdAsync(Guid conversationId);
        Task<Message> SendMessageAsync(Message message);
        Task DeleteMessageAsync(int messageId);
    }
}
