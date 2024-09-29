using ChatAppApi.Model;

namespace ChatAppApi.Interfaces
{
    public interface IUsersConversationRepository
    {
        Task<UsersConversation?> GetUsersConversationAsync(Guid conversationId, Guid userId);
        Task AddUserToConversationAsync(UsersConversation usersConversation);
    }
}
