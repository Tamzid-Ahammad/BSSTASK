using ChatAppApi.ViewModels;

namespace ChatAppApi.Hubs
{
    public interface IChatHub
    {
        Task SendMessage(string receiverUserId, MessageDto message);
        Task MessageDeleted(string conversationId, int messageId);


    }
}
